        string insertString = "INSERT INTO jiahe ([Tag ID], User, Age, [Phone Number]) VALUES (@TagID, @User, @Age, @PhoneNumber)";
        OleDbCommand ins = new OleDbCommand(insertString, objConnection);
        ins.Parameters.Add(new OleDbParameter("@TagID",newTagID);
        ins.Parameters.Add(new OleDbParameter("@User",newUser);
        ins.Parameters.Add(new OleDbParameter("@Age",newAge);
        ins.Parameters.Add(new OleDbParameter("@PhoneNumber",newPhoneNumber);
        ins.Connection.Open();
        ins.ExecuteNonQuery();
        ins.Connection.Close();
