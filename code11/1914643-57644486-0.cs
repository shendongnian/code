class FormController
{
    [HttpPost]
    public string Print(FormModel document)
    {
        if (document.Selection.Equals("Teacher"))
        {
            return WriteFile(...A.docx....);
        }
        else
        {
            return WriteFile(...B.docx....);
        }
    }
}    
public class FormModel {
    public string Selection { get; set; }
}
