    using org.pdfclown.bytes;
    using org.pdfclown.documents;
    using org.pdfclown.documents.files;
    using org.pdfclown.documents.interaction.annotations;
    using org.pdfclown.objects;
    
    using System;
    using System.Collections.Generic;
    
    void ExtractAttachments(string pdfPath)
    {
      Dictionary<string, byte[]> attachments = new Dictionary<string, byte[]>();
    
      using(org.pdfclown.files.File file = new org.pdfclown.files.File(pdfPath))
      {
        Document document = file.Document;
    
        // 1. Embedded files (document level).
        foreach(KeyValuePair<PdfString,FileSpecification> entry in document.Names.EmbeddedFiles)
        {EvaluateDataFile(attachments, entry.Value);}
    
        // 2. File attachments (page level).
        foreach(Page page in document.Pages)
        {
          foreach(Annotation annotation in page.Annotations)
          {
            if(annotation is FileAttachment)
            {EvaluateDataFile(attachments, ((FileAttachment)annotation).DataFile);}
          }
        }
      }
    }
    
    void EvaluateDataFile(Dictionary<string, byte[]> attachments, FileSpecification dataFile)
    {
      if(dataFile is FullFileSpecification)
      {
        EmbeddedFile embeddedFile = ((FullFileSpecification)dataFile).EmbeddedFile;
        if(embeddedFile != null)
        {attachments[dataFile.Path] = embeddedFile.Data.ToByteArray();}
      }
    }
