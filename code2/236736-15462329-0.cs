        [Themed(false)]
        public FileContentResult DownloadCSV()
        {
            
            var csvStringData = new StreamReader(Request.InputStream).ReadToEnd();
            csvStringData = Uri.UnescapeDataString(csvStringData.Replace("mydata=", ""));
            return File(new System.Text.UTF8Encoding().GetBytes(csvStringData), "text/csv", "report.csv");
        }
