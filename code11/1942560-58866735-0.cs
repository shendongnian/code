        public static void NotifyPipeOnProcessExit(
            Process processToMonitor,
            String pipeName
        )
        {
            // Create a pipe client.
            var client = new NamedPipeClientStream(".", pipeName, PipeDirection.Out);
            // create a process task
            var processTask = Task.Run(() => {
                processToMonitor.WaitForExit();
                using (client)
                {
                    client.Connect(0);
                    var sw = new StreamWriter(client);
                    sw.Write("Process exitted.");
                    sw.Close();
                }
            });
            return;
        }
