    var priceList = Test();
            const string downloadName = "PriceList.csv";
            var fs = new FileStream(downloadName, FileMode.Create);
            var csv = new CsvHelper.CsvHelper(fs);
            csv.Writer.WriteRecords(priceList);
            Response.ClearContent();
            //not sure what the correct content type is. This is probally wrong
            Response.ContentType = "application/xls";
            //Setting size is optional               
            Response.AddHeader("Content-Disposition",
               "attachment; filename=" + downloadName + "; size=" + fs.Length.ToString());
            var fn = fs.Name;
            fs.Close();
            loadingImage.Visible = false;
            Response.TransmitFile(fn);
            Response.Flush();
            Response.End();
