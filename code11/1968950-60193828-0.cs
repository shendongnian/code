        public async Task<bool> ActiveConnectionStatus()
        {
            try
            {
                var testObject = new ParseObject("Test");
                await testObject.SaveAsync();
                await testObject.DeleteAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine("ParseAccess: ActiveConnectionStatus(): CONNECTION STATUS FAIL: " + e);
                return false;
            }
            Debug.WriteLine("ParseAccess: ActiveConnectionStatus(): success");
            return true;
        }
