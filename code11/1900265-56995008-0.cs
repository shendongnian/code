 				using (Process p = new Process())
                {
                    string sImage = @"e:\test.jpg";
                    p.StartInfo.FileName = sImage;
                    p.StartInfo.Verb = "open";
                    p.StartInfo.UseShellExecute = true;
                    p.Start();
                }
                
