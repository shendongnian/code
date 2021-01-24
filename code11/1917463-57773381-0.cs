     try
     {
         string file = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".xml";
         using (FileStream fs = new FileStream(file, FileMode.Create, FileAccess.Write, FileShare.None))
         {
             XmlSerializer serializer = new XmlSerializer(typeof(FileTemplate));
             serializer.Serialize(fs, w.Template);
         }
         tempFile = Path.GetFileName(file);
     }
     catch(Exception ex)
     {
         
         logger.Error(ex.Message);
         //...
     }
     finally
     {
         //.... do stuff
         File.Delete(tempFile );
     }
