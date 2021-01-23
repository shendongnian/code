    public static bool ContainsAnyInt(this int int_, bool checkForNotContain_, params int[] values_)
    {
        if(values_ != null && values_.Contains(int_))
        {
           return !checkForNotContain_;
        }
        else
           return false;
    }
