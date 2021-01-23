    private static IEnumerable<PSObject> ExecutePowerShellScript(string script, bool isScript = false, IEnumerable<KeyValuePair<string, object>> parameters = null)
    {
        RunspaceConfiguration runspaceConfiguration = RunspaceConfiguration.Create();
        Runspace runspace = RunspaceFactory.CreateRunspace(runspaceConfiguration);
        runspace.Open();
        Command myCommand = new Command(script, isScript);
        if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    myCommand.Parameters.Add(new CommandParameter(parameter.Key, parameter.Value));
                }
            }
        Pipeline pipeline = runspace.CreatePipeline();
        
        pipeline.Commands.Add(myCommand);
        var result = pipeline.Invoke();
        
        // Check for errors
         if (pipeline.Error.Count > 0)
            {
                StringBuilder builder = new StringBuilder();
                //iterate over Error PipeLine until end
                while (!pipeline.Error.EndOfPipeline)
                {
                    //read one PSObject off the pipeline
                    var value = pipeline.Error.Read() as PSObject;
                    if (value != null)
                    {
                        //get the ErrorRecord
                        var r = value.BaseObject as ErrorRecord;
                        if (r != null)
                        {
                            //build whatever kind of message your want
                            builder.AppendLine(r.InvocationInfo.MyCommand.Name + " : " + r.Exception.Message);
                            builder.AppendLine(r.InvocationInfo.PositionMessage);
                            builder.AppendLine(string.Format("+ CategoryInfo: {0}", r.CategoryInfo));
                            builder.AppendLine(string.Format("+ FullyQualifiedErrorId: {0}", r.FullyQualifiedErrorId));
                        }
                    }
                }
                throw new Exception(builder.ToString());
             }
        return result;
    }
