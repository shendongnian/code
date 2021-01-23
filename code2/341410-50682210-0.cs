    using (FileStream fs = new FileStream(urlfile, FileMode.Create))
                            {
                                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                                {
                                    sw.Write(datasetHtmlreplacements);
                                    sw.Close();
                                }
                            }
