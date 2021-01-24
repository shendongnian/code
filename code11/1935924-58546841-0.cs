    if (resume.HasFile == true && resume.PostedFile.ContentLength > 0)
    {
        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(resume.FileName);
        string extension = Path.GetExtension(resume.FileName);
        string resumeName = "resume" + extension;
    
        BinaryReader Binary_Reader = new BinaryReader(resume.PostedFile.InputStream);
        byte[] File_Buffer = Binary_Reader.ReadBytes(resume.PostedFile.ContentLength);
        Binary_Reader = new BinaryReader(resume.PostedFile.InputStream);
        File_Buffer = Binary_Reader.ReadBytes(resume.PostedFile.ContentLength);
    
        var applicationToAdd = new LicenseApplicationAttachment
        {
            resumeName = resumeName,
            CompanyName = control.CompanyName,
            userid = Guid.NewGuid(),
            resumeContentType = resume.PostedFile.ContentType,
            resumeExtension = Path.GetExtension(resume.PostedFile.FileName),
            resumeSize = resume.PostedFile.ContentLength,
            resumeContent = File_Buffer
        };
    
    
        if (cv.HasFile == true)
        {
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(cv.FileName);
            string extension = Path.GetExtension(cv.FileName);
            string cvFileName = "cv" + extension;
    
            BinaryReader Binary_Reader = new BinaryReader(cv.PostedFile.InputStream);
            byte[] File_Buffer = Binary_Reader.ReadBytes(cv.PostedFile.ContentLength);
            Binary_Reader = new BinaryReader(cv.PostedFile.InputStream);
            File_Buffer = Binary_Reader.ReadBytes(cv.PostedFile.ContentLength);
            
            applicationToAdd.cvFileName = cvFileName;
            applicationToAdd.CompanyName = control.CompanyName;
            applicationToAdd.cvContentType = CapitalStructureShareHoldingFile.PostedFile.ContentType;
            applicationToAdd.cvExtension = Path.GetExtension(CapitalStructureShareHoldingFile.PostedFile.FileName);
            applicationToAdd.cvFileSize = CapitalStructureShareHoldingFile.PostedFile.ContentLength;
            applicationToAdd.cvFileContent = File_Buffer;
           
        } 
        myServiceCP.LicenseApplicationAttachments.Add(applicationToAdd);
        myServiceCP.SaveChanges();
    }
