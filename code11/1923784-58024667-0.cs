c#
class Program {
        private const string nameOne = "John";
        private const string nameTwo = "Mike";
        private void lblUser_Click (object sender, EventArgs e) {
            if (lblUser.Text == nameOne)
            {
                lblUser.Text = nameTwo;
            }else{
                lblUser.Text = nameOne;
            }
        }
    }
