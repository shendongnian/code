    interface ISaberpsicologiaExceptionHandler        
    {
      ActionResult Result<TException>(TException exception) where TException : SaberpsicologiaException;
    }
    
    public class MovedPermanentlyExceptionHandler : ISaberpsicologiaExceptionHandler
    {
      public ActionResult Result<TException>(TException exception) where TException : SaberpsicologiaException
      {
        if (exception is MovedPermanentlyException movedPermanentlyException)
        {
          var redirectResult = new RedirectResult(movedPermanentlyException.CannonicalUri);
            redirectResult.Permanent = true;
            return redirectResult;
         }
         throw new InvalidArgumentException("Exception type not supported", nameof(exception));
       }
    }
