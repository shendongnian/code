            try
            {
                Directory.Delete("path", true);
            }
            catch (IOException)
            {
                
            }
            finally
            {
                Directory.CreateDirectory("Path");
            }
