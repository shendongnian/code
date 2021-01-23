    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OpenFileDialog ofd = new  OpenFileDialog();
        private void Form1_Load(object sender, EventArgs e)
        {
        dataGridView1.Columns.Add("ID", "Product ID");
        
        DataGridViewComboBoxColumn comboxboxCol = new DataGridViewComboBoxColumn();
        comboxboxCol.HeaderText = "Type";
        comboxboxCol.Items.Add("Obj1");
        comboxboxCol.Items.Add("Obj2");
        comboxboxCol.Items.Add("Obj3");
        dataGridView1.Columns.Add(comboxboxCol);
        dataGridView1.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(Grid_EditingControlShowing);
        }
        void Grid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ComboBox combo = e.Control as ComboBox;
            if (combo != null)
            {
                // the event to handle combo changes
                EventHandler comboDelegate = new EventHandler(
                    (cbSender, args) =>
                    {
                        ofd.ShowDialog();
                    });
                // register the event with the editing control
                combo.SelectedValueChanged += comboDelegate;
            }
        }
    }
