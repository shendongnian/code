        public static String SaveTemplateSpreadsheetToServer()
        {
			// Open the workbook.
		    var templatename = HostingEnvironment.MapPath("~/Files/MyTemplate.xlsx");
	        
	        var workbook = Factory.GetWorkbook(templatename );
            
            // Read and write to the spreadsheet
            // Save a copy to disk and return filename       
            var filename = "The_exported_file.xlsx";
            var filePath = HostingEnvironment.MapPath("~/FilesTemp/" + filename);
            workbook.SaveAs(filePath, FileFormat.OpenXMLWorkbook);
			 // close workbook
			 workbook.Close();
            // Return the filename 
            return fileName;
        }
Method 2: Store the template on a webserver, extract and save modified spreadsheet as a byte array. Download directly an attachment
        public static byte[] SaveTemplateSpreadsheetToServer()
        {
			// Open the workbook.
		    var templatename = HostingEnvironment.MapPath("~/Files/MyTemplate.xlsx");
	        
	        var workbook = Factory.GetWorkbook(templatename );
            
            // Read and write to the spreadsheet
			// Save as byte array and send to user
			var byteArray = workbook.SaveToMemory(FileFormat.OpenXMLWorkbook);
			// close workbook
			workbook.Close();
            // Return the byte array
            return byteArray;
        }
We have done some work with binary template files saved in a database but find it more convenient to work with physical template files on a web server. It is easier to manage changes to the template.
My only caution is to avoid working with very big templates that have lots of "junk" in them (e.g. images). The process becomes affected by the time it takes to load the file into memory prior to the read / write / export activity. Less than 1MB is ideal and less than 2MB is manageable.
