    BindingList<Member> members = null;
    BindingSource membersSource = null;
    public partial class frmMembers : Form
    {
        public frmMembers() {
            InitializeComponent();
            InitializeDataBinding();
        }
        private void InitializeDataBinding()
        {
            members = new BindingList<Member>();
            membersSource = new BindingSource(members, null);
            lstBoxMembers.DataSource = membersSource;
            txtMemberName.DataBindings.Add(new Binding("Text", membersSource, 
                "FirstName", false, DataSourceUpdateMode.OnPropertyChanged));
            txtMemberLastName.DataBindings.Add(new Binding("Text", membersSource, 
                "LastName", false, DataSourceUpdateMode.OnPropertyChanged));
        }
        private void btnAddMember_Click(object sender, EventArgs e)
        {
            var frmNew = new frmNewMember();
            if (frmNew.ShowDialog() == DialogResult.OK && frmNew.newMember != null) {
                members.Add(frmNew.newMember);
            }
        }
        private void btnMovePrevious_Click(object sender, EventArgs e)
        {
            if (membersSource.Position > 0) {
                membersSource.MovePrevious();
            }
            else {
                membersSource.MoveLast();
            }
        }
        private void btnMoveNext_Click(object sender, EventArgs e)
        {
            if (membersSource.Position == membersSource.List.Count - 1) {
                membersSource.MoveFirst();
            }
            else {
                membersSource.MoveNext();
            }
        }
    }
