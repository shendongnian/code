    private void YourMethodThatTriesToCallWebService()
    {
        //Don't catch errors
    }
    public void TryToCallWebService(int numTries)
    {
        bool failed = true;
        for(int i = 0; i < numTries && failed; i++)
        {
            try{
                 YourMethodThatTriesToCallWebService();
                 failed = false;
            }catch{
                //do nothing
            }
        }
    }
