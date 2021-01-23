    using System.Windows.Forms;
    public static string GetControlV()
    {
        Textbox i = new Textbox();
        i.Paste();
        return i.Text;
    }
