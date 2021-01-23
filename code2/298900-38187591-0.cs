    protected void WaitForAjaxToComplete(int timeoutSecs)
            {
    
                var stopWatch = new Stopwatch();
    
                try
                {
                    while (stopWatch.Elapsed.TotalSeconds < timeoutSecs)
                    {
    
                        var ajaxIsComplete = (bool)(WebDriver as IJavaScriptExecutor).ExecuteScript("return jQuery.active == 0");
                        if (ajaxIsComplete)
                        {
                            break;
                        }
    
                    }
                }
                //Exception Handling
                catch (Exception ex)
                {
                    stopWatch.Stop();
                    throw ex;
                }
                stopWatch.Stop();
    
            }
