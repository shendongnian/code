    public partial class Form1 : Form
    {
        private ucHome HomeUserControl = new ucHome();
        private ucOperations OperationsUserControl = new ucOperations();
        private ucMaterials MaterialsUserControl = new ucMaterials();
        private ucSettings SettingsUserControl = new ucSettings();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            HomeUserControl.Dock = DockStyle.Fill;
            OperationsUserControl.Dock = DockStyle.Fill;
            MaterialsUserControl.Dock = DockStyle.Fill;
            SettingsUserControl.Dock = DockStyle.Fill;
        }
        private void UC_Bring(Control uc)
        {
            panelControls.Controls.Clear();
            panelControls.Controls.Add(uc);
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            UC_Bring(HomeUserControl);
        }
        private void btnOperations_Click(object sender, EventArgs e)
        {
            UC_Bring(OperationsUserControl);
        }
        private void btnMaterials_Click(object sender, EventArgs e)
        {
            UC_Bring(MaterialsUserControl);
        }
        private void btnSettings_Click(object sender, EventArgs e)
        {
            UC_Bring(SettingsUserControl);
        }
    }
    public class ucHome : UserControl { }
    public class ucOperations : UserControl { }
    public class ucMaterials : UserControl { }
    public class ucSettings : UserControl { }
