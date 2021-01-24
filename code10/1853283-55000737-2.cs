    [Cmdlet(VerbsCommon.Select, "Stuff")]
    public class SelectStuffCommand : PSCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public object[] InputObject;
        [Parameter()]
        public Hashtable Property;
        private List<string> _files;
        protected override void ProcessRecord()
        {
            string fileValue = string.Empty;
            foreach (var obj in InputObject)
            {
                if (!Property.ContainsKey("file"))
                    continue;
                if (Property["file"] is ScriptBlock)
                {
                    using (PowerShell ps = PowerShell.Create(InitialSessionState.CreateDefault2()))
                    {
                        var result = ps.AddCommand("ForEach-Object").AddParameter("process", Property["file"]).Invoke(new[] { obj });
                        if (result.Count > 0)
                        {
                            fileValue = result[0].ToString();
                        }
                    }
                }
                else
                {
                    fileValue = Property["file"].ToString();
                }
                _files.Add(fileValue);
            }
        }
        protected override void EndProcessing()
        {
            // process _files
        }
    }
