    public partial class addRecord : Form
    {
        public addRecord()
        {
            InitializeComponent();
            this.tbStudent.TextChanged += ValidateFields;
            this.tbScore.TextChanged += ValidateFields;
            btnOK.Enabled = false;
        }
        private string _Student;
        public string Student
        {
            get
            {
                return this._Student;
            }
        }
        private int _Score;
        public int Score
        {
            get
            {
                return this._Score;
            }
        }
        private void ValidateFields(object sender, EventArgs e)
        {
            bool valid = false; // assume invalid until proven otherwise
            // Make sure we have a non-blank name, and a valid mark between 0 and 100:
            if (this.tbStudent.Text.Trim().Length > 0)
            {
                int mark;
                if (int.TryParse(this.tbScore.Text, out mark))
                {
                    if (mark >= 0 && mark <= 100)
                    {
                        this._Student = this.tbStudent.Text.Trim();
                        this._Score = mark;
                        valid = true; // it's all good!
                    }
                }
            }
            this.btnOK.Enabled = valid;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
