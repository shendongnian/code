    using Word = Microsoft.Office.Interop.Word;
    using Office = Microsoft.Office.Core;
    public String getSelected(){
        Word.Document app = add_in.Globals.ThisAddIn.Application.ActiveDocument;
        String keyword = app.Application.Selection.Text;
        return keyword;
    }
