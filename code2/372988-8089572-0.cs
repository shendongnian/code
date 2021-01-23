    public class MyForm : Form
    {
        TextBox t = new TextBox();
        
        public string TBData
        {
            get { return t.Text; }
        }
    }
