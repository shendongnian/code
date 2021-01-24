 language: c#
Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
Microsoft.Office.Interop.Word.Documents docs = word.Documents;
Microsoft.Office.Interop.Word.Document doc = docs.Open("c:/temp/test.docx");
object saveFileName = "c:/temp/test.html";
doc.DeleteAllComments();
doc.SaveAs2(saveFileName, Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatHTML);
doc.Close();
