    public Form1()
    {
        InitializeComponents();
    
        this.Load += OnFormLoad;
    }
    private void OnFormLoad(object sender, EventArgs e)
    {
        for (int i = 0; i < 5; i++)
        {
            int j = 6;
            DataGridViewCellStyle CellStyle = new DataGridViewCellStyle();
            CellStyle.ForeColor = Color.Red;
            dataGridView1[j, i].Style = CellStyle;
            dataGridView1[j, i].Style.ApplyStyle(CellStyle);
        }
    }
