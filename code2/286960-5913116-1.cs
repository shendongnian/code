    public static class MyExtensionMethods
    {
        public static bool MyMethod(this MyWebService svc, params string[] a)
        {
            //The code below assumes you can pass in null if the parameter
            //is not specified. If you have to pass in string.Empty or something
            //similar then initialize all elements in the p array before doing
            //the CopyTo
            if(a.Length > 10) 
                throw new ArgumentException("Cannot pass more than 10 parameters.");
            var p = new string[10];
            a.CopyTo(p, 0);
            return svc.MyMethod(p[0], p[1], p[2], p[3], p[4], p[5], 
                                p[6], p[7], p[8], p[9]);
        }
    }
