    if (employee != null && employee.FirstName != null) {
        string name = employee.FirstName.TrimStart();
        if (name.Length > 0) {
            char firstChar = name[0];
            if (char.IsLetter(firstChar)) {
                textBoxLogin.Text = firstChar.ToString();
            }
        }
    }
