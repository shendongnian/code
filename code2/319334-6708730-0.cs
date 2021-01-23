    try
    {
         //Call Path.GetFullPath somewhere in here
    }
    catch (Exception ex)
    {
         if (ex is ArgumentException || ex is NotSupportedException || ex is PathTooLongException)
         {
              //Your handling here
         }
         else
         {
              throw;
         }
    }
