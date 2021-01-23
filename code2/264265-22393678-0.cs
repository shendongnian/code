    Try the Following Code:
    
    using System.Text.RegularExpressions;
    if  (!Regex.IsMatch(txtEmail.Text, @"^[a-z,A-Z]{1,10}((-|.)\w+)*@\w+.\w{3}$"))
            MessageBox.Show("Not valid email.");
