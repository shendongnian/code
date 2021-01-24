    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            var dataSet = new DataSet();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = dataSet.ReadXml("data.xml");
            comboBox1.DisplayMember = "Name";
            comboBox1.DataSource = dataSet.Tables[0];
            tbName.DataBindings.Add("Text", comboBox1.SelectedItem, "Name");
            tbType.DataBindings.Add("Text", comboBox1.SelectedItem, "type");
            tbLiving.DataBindings.Add("Text", comboBox1.SelectedItem, "living");
        }
    }
