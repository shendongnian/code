            List<string> files = new List<string>(); // list of files to merge
            foreach (string pageId in pages)
            {
                // create an intermediate page
                string intermediatePdf = Path.Combine(_tempPath, System.Guid.NewGuid() + ".pdf");
                files.Add(intermediatePdf);
                string pdfTemplate = Path.Combine(_templatePath, _template);
                
                CreatePage(pdfTemplate, intermediatePdf, pc, pageValues, imageMap, tmd);
             
            }
            // merge into resulting pdf file
            string outputFolder = "~/Output/";
            if (preview)
            {
                outputFolder = "~/temp/";
            }
            string pdfResult = Path.Combine(HttpContext.Current.Server.MapPath(outputFolder), Guid.NewGuid().ToString() + ".pdf");
            PdfMerge.MergeFiles(pdfResult, files);
            //////////////////////////////////////////////////////////////////////////
            // delete temporary files...
            foreach (string fd in files)
            {
                File.Delete(fd);
            }
            return pdfResult;
