    public Staff GetStaffById(int staffId)
    {
    	try
    	{
    		using (PosMainDBContext db = new PosMainDBContext())
    		{
    			return db.Staff.Where(s => s.StaffId == staffId).FirstOrDefault();
    		}
    		catch (Exception ex)
    		{
    			CustomExceptionHandling customExceptionHandling = new CustomExceptionHandling();
    			customExceptionHandling.CustomExHandling(ex.ToString());
    			return 0;
    		}
    	}
    }
    
