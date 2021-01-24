    public partial class frmNewMember : Form
    {
        public Member newMember;
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMemberName.Text) || 
                string.IsNullOrEmpty(txtMemberLastName.Text)) return;
            newMember = new Member(txtMemberName.Text, txtMemberLastName.Text);
        }
    }
