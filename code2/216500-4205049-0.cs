    public partial class IterationForm : Form
    { 
        // set this to the selected object (change to w/e type you need)
        public object SelectedObject{get; private set;}
        public IterationForm(string projectID)
        {
            InitializeComponent();
            LoadIterationsForProject(projectID);
        }
    
        private void LoadIterationsForProject(string projectID)
        {
            IterationRepository iterationRepo = new IterationRepository();
            Int64 ID = Convert.ToInt64(projectID);
            dgvIterations.DataSource = iterationRepo.FindAllIterations().Where(i => i.IDProject == ID).Select(i => new { Codigo = i.ID, Descripcion = i.Description, Inicio = i.StartDate, Fin = i.EndDate });
        }
    }
