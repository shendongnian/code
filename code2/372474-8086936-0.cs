    int success = 0;
    int fails = 0;
    for (int i = 0; i < 50; i++)
    {
        Runspace rs = RunspaceFactory.CreateRunspace();
        rs.Open();
        using (Pipeline pl = rs.CreatePipeline())
        {
            Command cmd = new Command("new-pssession");
            pl.Commands.Add(cmd);
            var retval = pl.Invoke();
            if (retval.Count > 0)
            {
                success++;
                PSSession Session = (PSSession)retval[0].BaseObject;
                using (Pipeline pl2 = rs.CreatePipeline())
                {
                    Command cmd2 = new Command("remove-pssession");
                    cmd2.Parameters.Add("Id", Session.Id);
                    pl2.Commands.Add(cmd2);
                    var retval2 = pl2.Invoke();
                    pl2.Stop();
                }
            }
            else
            {
                fails++;
            }
            pl.Stop();
        }
        rs.Close();
        rs = null;
    }
