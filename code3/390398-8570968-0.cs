     try
        {
        ...
        }
        catch(ServiceException ex)
        {
        	logException(ex);
        }
        catch(Exception ex)
        {
        	logException(ex);
        }
    
    public void logException(ex)
    {
    	if(ex is ServiceException)
    	{
    		logServiceException(ex as ServiceException)
    	}
    	else
    	{
    		logGenericException(ex)
    	}	
    }
    
    private void logGenericException(Exception ex)
    {
    ...
    }
    
