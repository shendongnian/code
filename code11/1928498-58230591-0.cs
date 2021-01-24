    private void Form1_Load(object sender, EventArgs e)
    {
        tabControl1.TabPages.Clear();
        PageForm1 f1 = new PageForm1();
        AddNewTab(f1);
    }
    private void AddNewTab(Form frm)
    {
        TabPage tab = new TabPage(frm.Text);
        frm.TopLevel = false;
        frm.Parent = tab;
        frm.Visible = true;
        tabControl1.TabPages.Add(tab);
        frm.Location = new Point((tab.Width - frm.Width) / 2, (tab.Height - frm.Height) / 2);
        tabControl1.SelectedTab = tab;
    }
    private void tabControl1_DoubleClick(object sender, EventArgs e)
    {
        Form f = (Form)Application.OpenForms[tabControl1.SelectedTab.Text];
        f.Close();
        tabControl1.TabPages.RemoveAt(tabControl1.SelectedIndex);
    }
