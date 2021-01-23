     public void SaveImage(string base64String, string filepath)
            {
                // image convert to base64string is base64String 
                //File path is which path to save the image.
                var bytess = Convert.FromBase64String(base64String);
                using (var imageFile = new FileStream(filepath, FileMode.Create))
                {
                    imageFile.Write(bytess, 0, bytess.Length);
                    imageFile.Flush();
                }
            }
