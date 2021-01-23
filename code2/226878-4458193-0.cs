    public EnResult MyFun()
    {
        // I changed 'default' to 'None' because I wasn't sure if it compiled
        EnResult result = EnResult.None;
    
        // block1 . higher priority than block2.
        if (true)
        {
            result = EnResult.true_1;
        }
        else
        {
            // do nothing
        }
    
        // block2
        if (result == EnResult.None)
        {
            if (true)
            {
                result = EnResult.true_2;
            }
            else
            {
                // do nothing
            }
        }
        return result;
    }
    
    public enum EnResult
    {
        None,  
        true_1,
        true_2,
        false_1,
        false_2,
        
    }
