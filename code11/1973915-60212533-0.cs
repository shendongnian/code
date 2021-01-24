       private void buttonPDFToEmail_Click(object sender, RibbonControlEventArgs e)
    {
        
       /* 
        * using Word = Microsoft.Office.Interop.Word;
        * using Outlook = Microsoft.Office.Interop.Outlook; => if running a Word VSTO projet, need to add that reference in solution's references.
        */
    
        // Word application.
        Word.Application wApp = Globals.ThisAddIn.Application;
        
        // Word document.
        Word.Document wDoc = Application.ActiveDocument;
    
        // instantiating Outlook application.
        Outlook.Application oApp = new Outlook.Application();
    
        // Generating the PDF filename.
        string filePDFName =
            (!String.IsNullOrEmpty(editBox_filePDFTitle.Text) & !String.IsNullOrWhiteSpace(editBox_filePDFTitle.Text)) ?
            editBox_filePDFTitle.Text :
            "PROJET";
      
        if (checkBox_addDate.Checked)
        {
            filePDFName += (char)32 + DateTime.Now.ToString("dd-MM-yyyy");
        }
    
        object fileName = @"C:\tmp\" + filePDFName;
    
        // Export activeDocument as PDF file.
        wDoc.ExportAsFixedFormat(
            fileName.ToString(),
            Word.WdExportFormat.wdExportFormatPDF
            );
    
         // Create a new email with no attachments.
        Outlook._MailItem oMailItem = (Outlook._MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);
        Outlook.Attachment oAttachment = null;
         
        // Adding our PDF file as attachement.
        oMailItem.Attachments.Add(fileName.ToString()+".pdf");
        oMailItem.Display(true);
    
        // using System.IO;
        // Deleting the tmp PDF file.
        File.Delete(fileName.ToString() + ".pdf");
    }
