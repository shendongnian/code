    int pagecount = 1;
    private void btAddtab_Click(object sender, EventArgs e)
    {
        TabPage tabPage = new TabPage
        {
            Name = "Tabpage" + pagecount.ToString(),
            Text = "Tabpage" + pagecount.ToString()
        };
        TextBox textBox = new TextBox
        {
            Name = "TextBox" + pagecount.ToString()
        };
        tabPage.Controls.Add(textBox);
        tabControl1.TabPages.Add(tabPage);
        pagecount++;
    }
