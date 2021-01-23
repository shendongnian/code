    try
    {  //;/;
        // your errorneous code goes here
    }
    catch(Exception ex)
    {
        StringBuilder sb = new StringBuilder();
        Exception innerEx = ex;
        while(innerEx != null)
        {
            sb.AppendLine(innerEx.Message);
            innerEx = innerEx.InnerException;
        }
        throw new Exception(sb.ToString());
    }
