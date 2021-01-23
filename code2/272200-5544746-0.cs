    using (MySqlConnection con = new MySqlConnection("host="";user="";password=""; database="";"))
    {
    	con.Open();
    	string strSQL = "INSERT INTO Patients(username, password, FirstName, SecondName, DiabetesType, Email,Phone, Phone2, Question1, Question2,TreatmentPlan) values (?name, ?password, .....)";
    	using (MySqlCommand cmd = new MySqlCommand(strSQL, con))
    	{
    		cmd.Parametrs.AddWithValue("?name", fname.Text);
    		cmd.Parametrs.AddWithValue("?password", lname.Text);
    		..........
    		cmd.ExecuteNonQuery();
    	}
    }
