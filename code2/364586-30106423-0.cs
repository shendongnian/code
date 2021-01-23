      bool TestMethod()
        {
            string _errorMessage = string.Empty;
            bool returnValue = true;
            try
            {
                int x;
                throw new Exception("Force Call To Error Handler");
            }
            catch (Exception ex)
            {
                _errorMessage = ex.ToString();
                goto errHandler;
            }
            //Other code here
            exitCode:
            ;
            return returnValue;
        //Exit code here
        errHandler:
            ;
            //Error Code Here
            returnValue = false;
            goto exitCode;
        }
