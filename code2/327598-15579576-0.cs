    private void rewriteXML(string oldFile, string newFile, int startPos, int strLength)
            {
                try
                {
                    File.Delete(newFile);
                }
                catch { Console.WriteLine("File existed."); }
                StreamReader SR = new StreamReader(oldFile);
                string data;
                StreamWriter SW = new StreamWriter(newFile);
                while ((data = SR.ReadLine()) != null)
                {
                    if (data.Contains("<start>"))
                    {
                        string ln_tmp = data.Replace(" ", "");
                        string newline = "    <start>" + ln_tmp.Substring(startPos, strLength) + "</start>";
                        SW.WriteLine(newline);
                    }
                    else
                        SW.WriteLine(data);
                }
                SR.Close();
                SW.Close();
            }
