    p.OutputDataReceived += new DataReceivedEventHandler
            (
                delegate(object sender, DataReceivedEventArgs e)
                {                   
                    using (StreamReader output = p.StandardOutput)
                    {
                        retMessage = output.ReadToEnd();
                    }
                }
            );
