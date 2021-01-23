        protected void btnPDF_Click(object sender, EventArgs e)
        {
            //Put the image you want to display in a MemoryStream.  You can read an image from the file system
            //or generate an image, etc.  This example renders an image to a memory stream using a custom charting control.
            MemoryStream chtLoginsByMonthStream = new MemoryStream();
            this.chtLoginsByMonth.Save(chtLoginsByMonthStream, ImageFormat.Png);
            //Setup the datatable you will pass into the RDLC
            dsStudentUsage.dtUsageChartsDataTable dt = new dsStudentUsage.dtUsageChartsDataTable();
            dsStudentUsage.dtUsageChartsRow dr = dt.NewdtUsageChartsRow();
            //create new Byte Array, this will hold the image data from the memory stream
            byte[] chtLoginsByMonthArray = new byte[chtLoginsByMonthStream.Length];
            
            //Set pointer to the beginning of the stream
            chtLoginsByMonthStream.Position = 0;
            //Read the entire stream
            chtLoginsByMonthStream.Read(chtLoginsByMonthArray, 0, (int)chtLoginsByMonthStream.Length);
            //Put the byte array into the new datarow in the appropriate column
            dr["imgLoginsByMonth"] = chtLoginsByMonthArray;
            dt.Rows.Add(dr);
            //Add the data source to the report.
            ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsStudentUsage_dtUsageCharts", dt));
            //Setup objects for streaming the PDF to the browser
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string extension;
            byte[] bytes;
           
            //Make a container for all of your report parameters
            var rptList = new List<KeyValuePair<string, string>>();
            rptList.Add(new KeyValuePair<string, string>("rpTotalLogins", "2,000"));
            //more parameters go here
            //Feed the report parameters into the actual "ReportParameters" class
            ReportParameter[] rptParams = new ReportParameter[rptList.Count];
            for (int i = 0; i < rptList.Count; i++)
            {
                rptParams[i] = new ReportParameter(rptList[i].Key, rptList[i].Value);
            }
            //Set parameters for the report.
            ReportViewer1.LocalReport.SetParameters(rptParams);
            //Render the report to a byte array in PDF format
            bytes = ReportViewer1.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamids, out warnings);
            
            //Set the stream to either prompt user as file download or "inline" to stream
            //PDF directly into the browser window.
            
            HttpContext.Current.Response.AddHeader("Content-disposition", "attachment; filename=StudentUsageReport.pdf");
            //HttpContext.Current.Response.AddHeader("Content-disposition", "inline;");
            HttpContext.Current.Response.ContentType = "application/pdf";
            HttpContext.Current.Response.BinaryWrite(bytes);
            HttpContext.Current.Response.End();
           
        }
