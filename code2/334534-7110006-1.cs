	public void MyProblematicMethod(int id, string name)
	{
		try
		{
			object o = null;
			int hash = o.GetHashCode(); // throws NullReferenceException
		}
		catch (Exception ex)
		{
			string error = SummarizeMethodCall(MethodBase.GetCurrentMethod(), id, name);
			// TODO: do something with this error
		}
	}
