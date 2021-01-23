            var Formcontent = ListFieldNames(Filepath);
            Formcontent["Name_txt"] = "T.Test";
            FillForm(Formcontent);
          //  var pdfContents = FillForm(pdfpath, Formcontent);
       
           
        }
        public Dictionary<string, string> ListFieldNames(string Filepath)
        {
          
            //PdfReader pdfReader = new PdfReader(pdfTemplate);
            //StringBuilder sb = new StringBuilder();
            //foreach(DictionaryEntry de in pdfReader.AcroFields.Fields)
            //{
            //    sb.Append(de.Key.ToString() + Environment.NewLine);
            //}
            var Fileds = new Dictionary<string, string>();
            PdfReader pdfReader = new PdfReader(Filepath);
            var reader = new PdfReader(pdfReader);
            foreach (var entry in reader.AcroFields.Fields)
                Fileds.Add(entry.Key.ToString(), string.Empty);
            reader.Close();
            return Fileds;
        }
        public byte[] FillForm(string pdfPath, Dictionary<string, string> formFieldMap)
        {
            var output = new MemoryStream();
            var reader = new PdfReader(pdfPath);
            var stamper = new PdfStamper(reader, output);
            var formFields = stamper.AcroFields;
            foreach (var fieldName in formFieldMap.Keys)
                formFields.SetField(fieldName, formFieldMap[fieldName]);
            stamper.FormFlattening = true;
            stamper.Close();
            reader.Close();
            return output.ToArray();
        }
        public void FillForm(Dictionary<string, string> Formfiledmap)
        {
            string pdfTemplate =Server.MapPath("/AOF.pdf");
            string newFile = @"C:\Users\USer\Desktop\completed_fw4.pdf";
            PdfReader pdfReader = new PdfReader(pdfTemplate);
            PdfStamper pdfStamper = new PdfStamper(pdfReader, new FileStream(newFile, FileMode.Create));
            AcroFields pdfFormFields = pdfStamper.AcroFields;
            foreach(var fieldName in Formfiledmap.Keys)
                pdfFormFields.SetField(fieldName,Formfiledmap[fieldName]);
          
          
            pdfStamper.FormFlattening = true;
            pdfStamper.Close();
        } 
