                var builder = new System.Text.StringBuilder("\"");
                foreach (clsField metadataItems in rule.Indexing)
                {
                    if (!Convert.IsDBNull(dr[metadataItems.FieldName.ToString()]))
                    {
                        builder.Append(dr[metadataItems.FieldName.ToString()].ToString());
                    }
                    builder.Append("\""+ strDelimiter +"\"");
                }
                string sData = builder.ToString();
                //sData = sData.Remove(sData.Length - 1);
                sData = sData.Remove(sData.Length - 1,1);
                    sw.Write(sData);
                    sw.Write(sw.NewLine);
                }
                sw.Close();
                Log("File " + sFileName + " Closed");
