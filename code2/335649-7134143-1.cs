        public MyForm()
        {
            InitializeComponent();
            // insert code here to add columns  ...
            // ...
            // ...
            // ...
            DataGridViewCellStyle oldDefault = dgview.ColumnHeadersDefaultCellStyle.Clone();
            dgview.ColumnHeadersDefaultCellStyle.BackColor = Color.Red;
            foreach (DataGridViewColumn item in dgview.Columns)
            {
                item.HeaderCell.Style = oldDefault;
            }
        }
