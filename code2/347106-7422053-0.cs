        foreach (file in filesArray)
        {
            try
            {
                System.Threading.Thread updateThread = new System.Threading.Thread(delegate()
                    {
                        WriteFileSynchronous(fileName, data);
                    });
                updateThread.Start();
            }
            catch (Exception ex)
            {
                string errMsg = ex.Message;
                Exception innerEx = ex.InnerException;
                while (innerEx != null)
                {
                    errMsg += "\n" + innerEx.Message;
                    innerEx = innerEx.InnerException;
                }
                errorMessages.Add(errMsg);
            }
        }
