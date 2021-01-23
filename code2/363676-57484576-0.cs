      public string[] DataSetToXmlStringArray(DataSet ds)
                {
                    MemoryStream streamSchema = new MemoryStream();
                    MemoryStream streamData = new MemoryStream();
                    ds.WriteXmlSchema(streamSchema);
                    ds.WriteXml(streamData);
                    string[] retStr = { "", "" };
                    retStr[0] = Encoding.Default.GetString(streamSchema.ToArray());
                    retStr[1] = Encoding.Default.GetString(streamData.ToArray());
                    return retStr;
                }
