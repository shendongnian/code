    public partial class MyForm : Form
    {
        public MyForm()
        {
            InitializeComponent();
            this.dGV.DataBindingComplete += 
                new DataGridViewBindingCompleteEventHandler(this.DataBindingComplete);
        }
        // ...
        private void DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Loops through each row in the DataGridView, and adds the
            // row number to the header
            foreach (DataGridViewRow dVRow in this.dGV.Rows)
            {
                dGVRow.HeaderCell.Value = String.Format("{0}", dGVRow.Index + 1);
            }
            
            // This resizes the width of the row headers to fit the numbers
            this.dGV.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        }
    }
