        public string ConvertFileToBase64String(string fileName)
        {
            byte[] fileContent = System.IO.File.ReadAllBytes(fileName);
            return Convert.ToBase64String(fileContent);
        }
