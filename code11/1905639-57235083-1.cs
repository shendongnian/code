    public partial class frmNewMember : Form
    {
        public Member newMember;
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtMemberName.Text == string.Empty || txtMemberLastName.Text == string.Empty) return;
            newMember = new Member(txtMemberName.Text, txtMemberLastName.Text);
        }
    }
