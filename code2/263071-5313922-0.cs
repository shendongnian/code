    object accessCode = cmd2.ExecuteScalar();
    if (accessCode != null && accessCode != DBNull.Value)
    {
        if (accessCode.ToString() == "1")
        {
           this.Hide();
           CarerHomePage CarerHomePage = new CarerHomePage();
           CarerHomePage.Show();
        }
