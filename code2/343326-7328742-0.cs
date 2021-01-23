                     System.Text.StringBuilder sb = new System.Text.StringBuilder();
                     while (reader.Read())
                        {
                            using (var fragmentReader = reader.ReadSubtree())
                            {
                                if (fragmentReader.Read())
                                {
                                    reader.ReadToFollowing("value");
                                    //Console.WriteLine(reader.ReadElementContentAsString() + ",");
    
                                    
                                    sb.Append(reader.ReadElementContentAsString()).Append(",");
                                }
                            }
                        }
                        Console.WriteLine(sb.ToString());
