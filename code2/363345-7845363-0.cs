        [WebMethod]
        public bool UploadFile(string fileName, string uploadFileAsBase64String)
        {
            try
            {
                byte[] fileContent = Convert.FromBase64String(uploadFileAsBase64String);
                string filePath = "UploadedFiles\\" + fileName;
                System.IO.File.WriteAllBytes(filePath, fileContent);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
