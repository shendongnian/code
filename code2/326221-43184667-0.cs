    catch (Exception ex)
    {
        if (ex.InnerException is ServiceResponseException)
           {
            ServiceResponseException srex = ex.InnerException as ServiceResponseException;
            string ErrorCode = srex.ErrorCode.ToString();
           }
    }
 
