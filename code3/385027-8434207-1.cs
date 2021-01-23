        string[] arr1;
        int loop1;
        HttpFileCollection Files;
        String TempFileName;
        HttpFileCollection MyFileCollection = Request.Files;
        Files = Request.Files; // Load File collection into HttpFileCollection variable.
        arr1 = Files.AllKeys;  // This will get names of all files into a string array.
        for (loop1 = 0; loop1 < arr1.Length; loop1++)
        {
            Response.Write("File: " + Server.HtmlEncode(arr1[loop1]) + "<br />");
            Response.Write("  size = " + Files[loop1].ContentLength + "<br />");
            Response.Write("  content type = " + Files[loop1].ContentType + "<br />");
            //TempFileName = "C:\\TempFiles\\File_" + loop1.ToString();
            TempFileName = Server.MapPath("~/") + "File_" + loop1.ToString();
            // Save the file.
            try
            {
                MyFileCollection[loop1].SaveAs(TempFileName);
            }
            catch (Exception ex)
            {
                Response.Write(" Write File Exception = " + ex + "<br />");
            }
            finally
            {
                Response.Write("Finally = No Exception" + "<br />");
            }
