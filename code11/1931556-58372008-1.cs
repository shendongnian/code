    catch (Exception ex)
          {
          
     
                  errMessage = string.Join(Environment.NewLine + "\t", ex.CollectThemAll(ex1 => ex1.InnerException)
                        .Select(ex1 => ex1.Message));
    Console.WriteLine(errMessage);
    }
