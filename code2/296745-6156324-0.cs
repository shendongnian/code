            /// <summary>
            /// Writes a message to the specified file name.
            /// </summary>
            /// <param name="Message">The message to write.</param>
            /// <param name="FileName">The file name to write the message to.</param>
            public void LogMessage(string Message, string FileName)
            {
                try
                {
                    using (TextWriter tw = new StreamWriter(FileName, true))
                    {
                        tw.WriteLine(DateTime.Now.ToString() + " - " + Message);
                    }
                }
                catch (Exception ex)  //Writing to log has failed, send message to trace in case anyone is listening.
                {
                    System.Diagnostics.Trace.Write(ex.ToString());
                }
            }
