    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Word = Microsoft.Office.Interop.Word;
    using System.IO;
    
    namespace PDF_EXTRACT
    {
    
        public class pdfTohtm
        {
    
            public static string ConvertPdf(string path, string outpath)
            {
                Word.Application app = new Word.Application(); ;
                Word.Document doc1;
                try
                {
    
                    doc1 = app.Documents.Open(path, false, ReadOnly: false);
                    app.DisplayAlerts = Word.WdAlertLevel.wdAlertsAll;
                    app.FileValidation = Microsoft.Office.Core.MsoFileValidationMode.msoFileValidationSkip;
                    app.Visible = false;
                    app.AutomationSecurity = Microsoft.Office.Core.MsoAutomationSecurity.msoAutomationSecurityForceDisable;
                    doc1.SaveAs2(outpath, Word.WdSaveFormat.wdFormatFilteredHTML, ReadOnlyRecommended: false);
                    doc1.Close();
                    string result = File.ReadAllText(outpath + ".htm", Encoding.UTF7);
                    return "success:" + result;
                }
                catch (Exception e)
                {
    
    
                    return "failed::::" + e;
    
    
                }
                finally
                {
                    app.Quit();
                    System.Runtime.InteropServices.Marshal.FinalReleaseComObject(app);
                }
    
            }
        }
    
    
    
    }
