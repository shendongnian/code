    private void Form1_Load(object sender, EventArgs e)
    {
        ContextMenu _blankContextMenu = new ContextMenu();
        textBox1.ContextMenu = _blankContextMenu; 
    }
        
    private const Keys CopyKeys = Keys.Control | Keys.C;
    private const Keys PasteKeys = Keys.Control | Keys.V;
    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        if ((keyData == CopyKeys) || (keyData == PasteKeys))
        {
            return true;
        }
        else
        {
            return base.ProcessCmdKey(ref msg, keyData);
        }
    } 
