     using (var sw = new StreamWriter(
                                    
     new FileStream(temporaryFilePath,    
                   FileMode.Create,
                   FileAccess.ReadWrite), 
                   Encoding.UTF8))
                {
                    sw.Write(sb.ToString());
                }
     )
