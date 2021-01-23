    catch (Exception ex)  // PLEASE catch something more specific.
    {
       LogException(ex.Message);
       if (ex.InnerException != null)
       {
          LogInnerException(ex.InnerException.Message);
       }
    }
