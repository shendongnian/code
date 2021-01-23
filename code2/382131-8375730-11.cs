    using (WordprocessingDocument doc = WordprocessingDocument.Open(filename, true))
    {
       MainDocumentPart mp = doc.MainDocumentPart;
 
       foreach(SdtContentCheckBox cb in mp.Document.Body.Descendants<SdtContentCheckBox>())
       {         
         if(cb.Checked.Val == "1");
         {
           Console.Out.WriteLine("CHECKED");  
         }           
       }
    }
