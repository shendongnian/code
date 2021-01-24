    public Form1()
        {
            InitializeComponent();
            this.dataGridView1.CellFormatting += DataGridView1_CellFormatting;
            this.dataGridView1.Rows.Add("five");
            this.dataGridView1.Rows.Add("235656.5477");
            this.dataGridView1.Rows.Add("24.54"); 
        }
    private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (Microsoft.VisualBasic.Information.IsNumeric(e.Value))
        {
            DataGridViewCellStyle numberFont = new DataGridViewCellStyle(dataGridView1.DefaultCellStyle);
            numberFont.Alignment = DataGridViewContentAlignment.MiddleRight;
            Font newFont = new Font(dataGridView1.Font.Name, 15, FontStyle.Regular);
            numberFont.Font = newFont;
            numberFont.ForeColor = Color.Red;
            numberFont.Format = "{0:#,0.####}";
            e.CellStyle = numberFont;
            e.Value = string.Format("{0:#,0.####}", Decimal.Parse(e.Value.ToString()));
        }
    }
