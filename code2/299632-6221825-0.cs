    using (MemoryStream ms = new MemoryStream())  
    {    
        PdfReader reader = new PdfReader("~/Content/Documents/Agreement.pdf");
        ///////////////////////////////////////////////////////////
        // Modified code    
        string newFile = @".\FormDocument_out.pdf";    
        PdfStamper formFiller = new PdfStamper(reader, new FileStream(newFile, FileMode.Create));
        ///////////////////////////////////////////////////////////
        AcroFields formFields = formFiller.AcroFields;
        formFields.SetField("Name", formData.Name);
        formFields.SetField("Location", formData.Address);
        formFields.SetField("Date", DateTime.Today.ToShortDateString());
        formFields.SetField("Email", formData.Email);
        formFiller.FormFlattening = true;
        formFiller.Close();
    }
