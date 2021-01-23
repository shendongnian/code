            bool hasHistory = false;
            try
            {
                webBrowser1.InvokeScript("eval");
                hasHistory = true;
            }
            catch (SystemException ex)
            {
                hasHistory = false;
            }
