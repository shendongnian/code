    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Office.Interop.Word;
    using Word = Microsoft.Office.Interop.Word;
    using System.IO;
    
    namespace WordIterator
    {
        class Program
        {
            static void Main(string[] args)
            {
                string FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Test.docx");
                Document doc = null;
                Application wordApp1 =new Application();
                Application wordApp2 = new Application();
                string FilePath2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Test_2.docx");
                try
                {
                    object fileName = FilePath;
                    object fileName2 = FilePath2;
                    wordApp1 = new Application { Visible = true };
                    doc = wordApp1.Documents.Open(ref fileName, ReadOnly: false, Visible: true);
                    doc.SaveAs2(FilePath.Replace(".docx", "_2.docx"));
                    doc.Close();
                    Document doc2 = wordApp1.Documents.Open(ref fileName2, ReadOnly: false, Visible: true);
                }
                catch (Exception ex)
                {
    
                }
                finally
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(doc);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp1);
                }
            }
        }
    }
