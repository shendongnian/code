    int p1 = -1; //Or some impossible value.  This could also be a int? and left as null until it is initialized.
    public static int P1
    {
        get //Define only the 'get' of the property for this to make it readonly
        {
            if (p1 == -1)
               //Insert Code to get the value from your DB.
            return p1;
        }
    }
