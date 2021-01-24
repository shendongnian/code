         List<UserInfo> users = new List<UserInfo>();
         using (var reader = new StreamReader(inputStream))
                {
                    //read first line with headers
                    var metaDataLine = reader.ReadLine() ?? "";
                    //get array with headers
                    string[] csvMetada = metaDataLine.Split(',');  
                       while (!reader.EndOfStream)
                        { 
                         // create model based on string data and columns metadata with columns                      
                         UserInfo newModel =   ConvertCSVToEntity(reader.ReadLine() ?? "", csvMetada);
                         users.add(newModel);
                        }
                    }
