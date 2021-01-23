	DataTable dtStudent = new DataTable();
	//Add new column
	dtStudent.Columns.AddRange(
		new DataColumn[] { new DataColumn("SlNo", typeof(int)),
		new DataColumn("RollNumber", typeof(string)),
		new DataColumn("DateOfJoin", typeof(DateTime)),
		new DataColumn("Place", typeof(string)),
		new DataColumn("Course", typeof(string)),
		new DataColumn("Remark", typeof(string))
	});
	// Add value to the related column 
	dtStudent.Rows.Add(1, "10001", DateTime.Now, "Bhubaneswar", "MCA", "Good");
