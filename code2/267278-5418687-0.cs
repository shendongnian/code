	public static string displayComment( string username, string AssignedTo, string NALComment, int refID, string Process) 
	{
		// various junk code removed, testing user and rights
		// here we know we have the right user, he or she needs the edit URL
		// two parameters are passed, first the refID, second the Process (or document)
		string e = "<a href =\"../Process/" + refID.ToString() + "/" + Process +"/\">Edit</a> " + NALComment;
		
		return e;
	}
