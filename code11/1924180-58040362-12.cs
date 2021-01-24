    // General interface
    interface ISaberpsicologiaExceptionHandler
    {
      ActionResult Result(Exception exception);
    }
    
    // Specialized interface
    interface IMovedPermanentlyExceptionHandler : ISaberpsicologiaExceptionHandler
    {
      ActionResult Result(MovedPermanentlyException exception);
    }    
    
    public class MovedPermanentlyExceptionHandler : IMovedPermanentlyExceptionHandler
    {
      public ActionResult Result(MovedPermanentlyException exception)
      {
        var redirectResult = new RedirectResult(exception.CannonicalUri);
        redirectResult.Permanent = true;
    
        return redirectResult;
      }
    
      #region Implementation of ISaberpsicologiaExceptionHandler
    
      // Explicit interface implementation
      ActionResult ISaberpsicologiaExceptionHandler.Result(Exception exception)
      {
        if (exception is MovedPermanentlyException movedPermanentlyException)
        {
          return Result(movedPermanentlyException);
        }
        throw new InvalidArgumentException("Exception type not supported", nameof(exception));
      }    
      #endregion
    }
