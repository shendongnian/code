    class Generator : Form
    {
        public string Text1 { get; private set; }
    
        void ok_Click (object sender, EventArgs)
        {
            this.Text1 = txt1.Text;
            ...
            this.Close();
        }
    }
    
    Form gen = new Generator();
    gen.ShowDialog();
    string text1 = gen.Text1;
    ...
---
    class TextInfo
    {
        public string Text1 { get; set; }
        ...
    }
    class Generator : Form
    {
        public TextInfo Textinfo { get; private set; }
    
        public Generator(TextInfo info)
        {
            this.TextInfo = info;
        }
    
        void ok_Click (object sender, EventArgs)
        {
            this.TextInfo.Text1 = txt1.Text;
            ...
            this.Close();
        }
    }
    TextInfo info = new TextInfo();
    Form gen = new Generator(info);
    gen.ShowDialog();
    string text1 = info.Text1;
