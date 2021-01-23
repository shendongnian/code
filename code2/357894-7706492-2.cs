    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            listViewEx1.SetHeaderDropdown(0, true);
            listViewEx1.HeaderDropdown += listViewEx1_HeaderDropdown;
        }
        void listViewEx1_HeaderDropdown(object sender, ListViewEx.HeaderDropdownArgs e) {
            e.Control = new UserControl1();
        }
    }
