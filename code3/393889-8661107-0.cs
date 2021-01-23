            public Form1()
        {
            InitializeComponent();
            MyDataGridViewInitializationMethod();
        }
        private void MyDataGridViewInitializationMethod()
        {
            dataGridView1.EditingControlShowing +=
        new DataGridViewEditingControlShowingEventHandler(dataGridView1_EditingControlShowing);
        }
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress +=
                new KeyPressEventHandler(Control_KeyPress);
        }
        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                string cellValue = Char.ToString(e.KeyChar);
                //Get the column and row position of the selected cell
                int column = dataGridView1.CurrentCellAddress.X;
                int row = dataGridView1.CurrentCellAddress.Y;
                if (column == 1)
                {
                //Gets the value that existings in that cell
                string test = dataGridView1[column, row].EditedFormattedValue.ToString();
                //combines current key press to the contents of the cell
                test = test + cellValue;
                int intNumberBoxes = Convert.ToInt32(test);
                //Some amount to mutiple the numberboxes by
                int someAmount = 10;
                dataGridView1[column + 1, row].Value = intNumberBoxes * someAmount;
                }
            }
        }
        
    }
