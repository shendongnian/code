    void Startup()
    {
        _Outlook = new Outlook.Application();
    }
    Outlook.Application _Outlook = null;
    private void Form1_DragEnter(object sender, DragEventArgs e)
    {
        e.Effect = DragDropEffects.Copy;
    }
    private void Form1_DragDrop(object sender, DragEventArgs e)
    {
        richTextBox1.Text = "";
        Outlook.Explorer oExplorer = _Outlook.ActiveExplorer();
        Outlook.Selection oSelection = oExplorer.Selection;
        foreach (object item in oSelection)
        {
            Outlook.MailItem mi = (Outlook.MailItem)item;
            richTextBox1.AppendText(mi.Body.ToString() + "\n----------------------------------------\n");
        }
    }
