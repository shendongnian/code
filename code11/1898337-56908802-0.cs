        public class DBRowObject { // The object that will be stored in the "DataSource" of the ComboBox
            public int iPrice = 0;
            public string strName = "";
            public DBRowObject(int price, string name) {
                iPrice = price;
                strName = name;
            }
            public override string ToString() // This means the combo box will display the name
            {
                return strName;
            }
        }
        public Form1()
        {
            InitializeComponent();
            List<DBRowObject> lsRows = new List<DBRowObject>(){new DBRowObject(3,"Bob"),new DBRowObject(2,"Sam"),new DBRowObject(5,"John")};
            this.cbCombo.DataSource = lsRows;
        }
        public DBRowObject prevSelected = null;
        private void cbCombo_SelectedValueChanged(object sender, EventArgs e)
        {
            DBRowObject dbrCurr = (DBRowObject)cbCombo.SelectedItem;
            if (prevSelected != null) {
                dbrCurr.iPrice += prevSelected.iPrice;
            }
            // TODO Display information about these objects and perform various other tasks
            prevSelected = dbrCurr;
        }
