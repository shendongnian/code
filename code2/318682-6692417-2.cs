    public Form1()
    {
        InitializeComponents();
    
        this.Load += OnFormLoad;
        this.dataGridView1.Sorted += OnDataGridSorted;
    }
    private void OnFormLoad(object sender, EventArgs e)
    {
        UpdateDataGridViewColor();
    }
    private void OnDataGridSorted(object sender, EventArgs e)
    {
        UpdateDataGridViewColor(); 
    }
    private void UpdateDataGridViewColor()
    {
        for (int i = 0; i < 5; i++)
        {
            int j = 6;
            DataGridViewCellStyle CellStyle = new DataGridViewCellStyle();
            CellStyle.ForeColor = Color.Red;
            dataGridView1[j, i].Style = CellStyle;
        }
    }
