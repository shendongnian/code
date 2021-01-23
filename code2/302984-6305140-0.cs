    public static void AddNewDluznik(string fName, string lName, int case)
    {
         var row = MainData.User.NewUserRow();
         row.U_fname = fName;
         row.U_lname = lName;
         row.U_Case = case; 
         MainData.User.AddUserRow(row);
    }
