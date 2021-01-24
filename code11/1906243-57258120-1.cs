    public partial class Form1 : Form
    {
        private ProgramState programState = new ProgramState();
        public Form1()
        {
            InitializeComponent();
        }
        private void btnAcceptAgreement_Click(object sender, EventArgs e)
        {
            programState.UserAcceptedAgreement = true;
        }
        private void btnAcceptLiability_Click(object sender, EventArgs e)
        {
            programState.UserAcknowledgedLiability = true;
        }
        private void btnSubmitSignature_Click(object sender, EventArgs e)
        {
            programState.UserSubmittedSignature = true;
        }
        public void verify()
        {
            if (programState.EverythingAccepted)
            {
                tabControl.SelectedIndex = 2;
            }
            else
            {
                MessageBox.Show("Enter parameters");
            }
        }
    }
