        public FileContentResult DownloadCSV()
        {
            string csv = "Charlie, Chaplin, Chuckles";
            return File(new System.Text.UTF8Encoding().GetBytes(csv), "text/csv", "Report123.csv");
        }
