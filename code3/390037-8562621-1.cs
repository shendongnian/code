    private void RunAndHandleExceptions(Action action)
            {
                try
                {
                    action.Invoke();
                }
                catch (ServiceException ex)
                {
                    ModelState.Merge(ex.Errors);
                }
                catch (Exception e)
                {
                    Trace.Write(e);
                    ModelState.AddModelError("", "Database access error: " + e.Message);
                }
            }
