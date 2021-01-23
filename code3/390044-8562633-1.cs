    private void HandleException(Action<IEnumerable<string>> action, 
      IEnumerable<string> parameters)
    {
      try {
        action(parameters);
      }
      catch (ServiceException ex) {
        ModelState.Merge(ex.Errors);
      }
      catch (Exception e) {
        Trace.Write(e);
        ModelState.AddModelError("", "Database access error: " + e.Message);
      }
    }
