    IEnumerable<Student> list = (IEnumerable<Student>)this.DataContext;
    foreach(Student stu in Students)
    {
    	Debug.WriteLine(stu.StudentID + ":");
    	foreach(Subject sub in stu.Subjects)
    	{
    		Debug.WriteLine("\\t" + sub.SubjectID)
    	}
    }
