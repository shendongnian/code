    using Microsoft.Office.Interop.Word;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    
    ...
    
    // Create a new Microsoft Word application object
    Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
    
    // C# doesn't have optional arguments so we'll need a dummy value
    object oMissing = System.Reflection.Missing.Value;
    // Get a Word file
    FileInfo wordFile = new FileInfo("myDoc.doc");
    word.Visible = false;
    word.ScreenUpdating = false;
    
    // Cast as Object for word Open method
    Object filename = (Object)wordFile.FullName;
    
    // Use the dummy value as a placeholder for optional arguments
    Document doc = word.Documents.Open(ref filename, ref oMissing,
        ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
        ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
        ref oMissing, ref oMissing, ref oMissing, ref oMissing);
    doc.Activate();
    
    object outputFileName = wordFile.FullName.Replace(".doc", ".pdf");
    object fileFormat = WdSaveFormat.wdFormatPDF;
    
    // Save document into PDF Format
    doc.SaveAs(ref outputFileName,
        ref fileFormat, ref oMissing, ref oMissing,
        ref oMissing, ref oMissing, ref oMissing, ref oMissing,
        ref oMissing, ref oMissing, ref oMissing, ref oMissing,
        ref oMissing, ref oMissing, ref oMissing, ref oMissing);
    
    // Close the Word document, but leave the Word application open.
    // doc has to be cast to type _Document so that it will find the
    // correct Close method.                
    object saveChanges = WdSaveOptions.wdDoNotSaveChanges;
    ((_Document)doc).Close(ref saveChanges, ref oMissing, ref oMissing);
    doc = null;
    
    // word has to be cast to type _Application so that it will find
    // the correct Quit method.
    ((_Application)word).Quit(ref oMissing, ref oMissing, ref oMissing);
    word = null;
