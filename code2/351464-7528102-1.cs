	public DataTable GetStudentsByClass(int classId)
	{
		//Set the connection string to the database and open the connection
		Con1_1.ConnectionString = conStr;
		Con1_1.Open();
		
		//Execute the SQL query
		databaseAdapter = new SqlDataAdapter("SELECT * From Students WHERE ClassId = " + classId, Con1_1);
		
		//Declare a datatable to fill
		DataTable students;
		
		//Fill the datatable with the results
		databaseAdapter.Fill(students, "Students");
		
		//Return the filled datatable
		return students;
	}
	public int GetStudentsInClassCount(int classId)
	{
		//Here you can reuse the previous method to get the count, a more optimal way would be to use the SQL count though.
		return GetStudentsByClass(classId).Rows.Count;
	}
