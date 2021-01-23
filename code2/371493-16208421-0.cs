    // Read the CSV file name & file path  
                // I am usisg here Kendo UI Uploader  
                string path = "";  
       string filenamee = "";  
       if (files != null)  
       {  
         foreach (var file in files)  
         {  
           var fileName = Path.GetFileName(file.FileName);  
           path = Path.GetFullPath(file.FileName);  
           filenamee = fileName;  
         }  
                     // Read the CSV file data  
         StreamReader sr = new StreamReader(path);  
         string line = sr.ReadLine();  
         string[] value = line.Split(',');  
         DataTable dt = new DataTable();  
         DataRow row;  
         foreach (string dc in value)  
         {  
           dt.Columns.Add(new DataColumn(dc));  
         }  
         while (!sr.EndOfStream)  
         {  
           value = sr.ReadLine().Split(',');  
           if (value.Length == dt.Columns.Count)  
           {  
             row = dt.NewRow();  
             row.ItemArray = value;  
             dt.Rows.Add(row);  
           }  
         }  
