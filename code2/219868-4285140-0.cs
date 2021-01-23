            bool patternwritten = false;
            while ((line = file.ReadLine()) != null)
                                    {
              if (line.IndexOf(line2,StringComparison.CurrentCultureIgnoreCase) != -1)
                    if( !patternwritten){
                      dest.WriteLine("Pattern Name :" + line2);
                      patternwritten = true;
                    }
                    dest.WriteLine("LineNo : " + counter.ToString() + " : " + line);
                                        counter++;
                                    }
                                    file.BaseStream.Seek(0, SeekOrigin.Begin);
                                        //(0, SeekOrigin.Begin);
                                    counter = 1;
