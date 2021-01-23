	public Task Update(Task task)
	{
		isLocked = true;
		try
		{
			//DO OTHER STUFF HERE
		}
		catch(Exception ex)
		{
			// error logging here
		}
		finally
		{
			UpdateToDB(task)
		}
		return task;
	}
	private Task UpdateToDB(Task task)
	{
		try
		{
			task.locked = false
			task.DateLocked = "6/3/1900";
			task.Commit();     
		}
		catch(Exception e)
		{
			//LOG ERROR
		}
		catch(SqlException ex)
		{
		   //LOG ERROR
		   // "database is down error to user"
		}
		isLocked = false;
		return task
	}
	
