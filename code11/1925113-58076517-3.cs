    private static bool IsNameValid(string name) {
      if (string.IsNullOrEmpty(name))
        return true;
      else if (name.Any(c => c < '0' || c > '9')) {
        MessageBox.Show("Your User ID must contain digits only!");
        return false;
      }
      else if (name.StartsWith("0")) {
        MessageBox.Show("Your User ID must not start from 0!");
        return false;
      }
      return true;
    }
    private void TxtUserID_TextChanged(object sender, EventArgs e) {
      if (!IsNameValid(TxtUserID.Text))
        txtUserID.Clear(); // Taken from the question
    }
