                using (var str = File.OpenRead(pathToAssembly))
                {
                    int count = 0;
                    do
                    {
                        var buffer = new byte[1024];
                        count = str.Read(buffer, 0, 1024);
                        for (int i = 0; i < count; i++)
                        {
                            hexStringBuilder.Append((buffer[i] >> 4).ToString("X"));
                            hexStringBuilder.Append((buffer[i] & 0xF).ToString("X"));
                        }
                    } while (count > 0);
                }
                // generate script using template from initial question
