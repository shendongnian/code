    public class Customer
    {
        private String name;
        public String Name
        {
            get {return this.name; }
            set {this.name = value; }
        }
        private int id;
        public int Id
        {
            get {return this.id; }
            set {this.id = value; }
        }
    }
    public class CustomerCbx
    {
        private String display;
        public String Display
        {
            get {return this.display; }
            set {this.display = value; }
        }
        private Customer value;
        public Customer Value
        {
            get {return this.value; }
            set {this.value = value; }
        }
    }
    public class Form{
    private void Form_OnLoad(object sender, EventArgs e)
    {
            //init first row in the dgv
            if (this.dgv.RowCount > 0)
            {
                DataGridViewRow row = this.dgv.Rows[0];
                DataGridViewComboBoxCell cbx = (DataGridViewComboBoxCell)row.Cells[0];
                
                Customer c1 = new Customer(){ Name = "Max Muster", ID=1 };
                Customer c2 = new Customer(){ Name = "Peter Parker", ID=2 };
                List<CustomerCbx> custList = new List<CustomerCbx>()
                {
                    new CustomerCbx{ Display = c1.Name, Value = c1},
                    new CustomerCbx{ Display = c2.Name, Value = c2},
                }
                InitDGVComboBoxColumn<CustomerCbx>(cbx, custList, "display", "value");
            }
        }
    }
    }
