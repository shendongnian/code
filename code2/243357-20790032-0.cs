    public partial class pt_drug : PatientDatabase1_3._5.basic_templet
    {
        public pt_drug()
        {
            InitializeComponent();
            dataGridView_drugsDM.Rows[0].Cells[0].Value = "Tablet";
        }
        private void dataGridView_drugsDM_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            dataGridView_drugsDM.Rows[dataGridView_drugsDM.RowCount - 1].Cells[0].Value = "Tablet";
        }
      
    }
