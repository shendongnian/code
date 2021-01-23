    public class MyForm : Form
    {
        TextBox t = new TextBox();
        
        public string TBData
        {
            get { return t.Text; }
        }
    }
    // outside:
    Form f = new MyForm();
    f.Show()
    //f.TBData will get what is in the text box.
