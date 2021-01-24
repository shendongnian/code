    public partial class addRecord : Form
    {
        public addRecord()
        {
            InitializeComponent();
        }
        private string _Student;
        public string Student
        {
            get
            {
                return this._Student;
            }
        }
        private string _Score;
        public string Score
        {
            get
            {
                return this._Score;
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            this._Student = this.tbStudent.Text;
            this._Score = this.tbScore.Text;
            this.DialogResult = DialogResult.OK;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
