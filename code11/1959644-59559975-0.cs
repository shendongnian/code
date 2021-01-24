    public string ExportToCsv(IEnumerable<Student> students)
    {
    	var output = new StringBuilder();
    	// Add header if necessary
    	output.Append("Name,");
    	output.Append("Age ,");
    	output.Append("Course ,");
    	output.Append("JoiningDate ,");
    	output.Append("CourseName ,");
    	output.Append("CourseID ,");
    	output.AppendLine();
    	// Add each row
    	foreach (var student in students)
    	{
    		output.AppendFormat("{0},", student.Name);
    		output.AppendFormat("{0},", student.Age);
    		output.AppendFormat("{0},", student.Course);
    		output.AppendFormat("{0},", student.JoiningDate);
    		output.AppendFormat("{0},", student.CourseName);
    		output.AppendFormat("{0},", student.CourseID);
    		output.AppendLine();
    	}
    }
