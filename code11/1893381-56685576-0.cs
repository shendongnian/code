            DataTable dt = new System.Data.DataTable();  
            dt.TableName = "Details";  
           dt.Columns.Add("phone", typeof(string));  
            dt.Columns.Add("houseNumber", typeof(string));  
             dt.Columns.Add("date", typeof(string));  
            dt.Columns.Add("deliveryId", typeof(string)); 
        
            dt.Rows.Add("1234567", "45","2015-09-19","KV12_3896096015");  
         
           //Create Temp directory to save xml file  
            var tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());  
             Directory.CreateDirectory(tempDir);  
            string path = Path.Combine(tempDir, string.Format("{0}.{1}", "Prodcuts", "xml"));  
           //Write to xml file  
            dt.WriteXml(path, System.Data.XmlWriteMode.IgnoreSchema);  
            //Create HttpClient and MultipartFormDataContent  
            using (var client = new HttpClient())  
            using (var formData = new MultipartFormDataContent())  
            using (var fromFile=File.OpenRead(path))  
            {  
                formData.Add(new StringContent("Test"), "FileName");  
                formData.Add(new StringContent("xlsx"), "FileFormat");  
                formData.Add(new StreamContent(fromFile), "DataFile",Path.GetFileName(path));  
                //Call WebAPI  
                var response = client.PostAsync(webapiURL, formData).Result;  
                if (!response.IsSuccessStatusCode)  
                {  
                    MessageBox.Show("Invalid response.");  
                    return;  
                }  
                var tempPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());  
                if (!Directory.Exists(tempPath))  
                {  
                    Directory.CreateDirectory(tempPath);  
                }  
                //Save Excel file to Temp directory  
}
