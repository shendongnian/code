    private void HandleException(Action action)
    {
      try {
        action();
      }
      catch (ServiceException ex) {
        ModelState.Merge(ex.Errors);
      }
      catch (Exception e) {
        Trace.Write(e);
        ModelState.AddModelError("", "Database access error: " + e.Message);
      }
    }
