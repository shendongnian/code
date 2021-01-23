    catch (Exception ex)
    {
      if (ex.Message.Contains("Yikes!"))
      {
        // Do your thing
      }
      ...
      else
      {
        throw;
      }
    }
