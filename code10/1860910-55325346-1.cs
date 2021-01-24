    public partial class MyForm : Form
    {
        private List<Dino> _dinoList;
        BindingSource _bindingSource;
        public MyForm()
        {
            InitializeComponent();
            _dinoList = new List<Dino>();
            _bindingSource = new BindingSource();
            _bindingSource.DataSource = _dinoList;
            lbDinos.DisplayMember = nameof(Dino.Name);
            lbDinos.DataSource = _bindingSource;
        }
        private void btnAddData_Click(object sender, EventArgs e)
        {
            _dinoList.Add(new Dino(txtDinoName.Text));
            // Reload data
            _bindingSource.ResetBindings(false);
            // Select last inserted
            lbDinos.SelectedIndex = (lbDinos.Items.Count - 1);
        }
    }
    public class Dino
    {
        public string Name { get; set; }
        public Dino(string name)
        {
            Name = name;
        }
    }
