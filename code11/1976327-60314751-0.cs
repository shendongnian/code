    private void Form1_Load(object sender, EventArgs e)
    {
        this.fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.Lua;
        this.fastColoredTextBox1.Text= "function echo(s) return s end" + "\n" +
            "return echo(\"Hello!\")";
    }
    private void toolStripButton1_Click(object sender, EventArgs e)
    {
        dynamic lua = new DynamicLua.DynamicLua();
        var result = lua(fastColoredTextBox1.Text);
        MessageBox.Show($"{result}"); 
    }
