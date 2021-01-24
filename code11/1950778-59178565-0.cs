    public static int getval (string varname)
            {
                return (int)typeof(PowerComINC).GetField(varname).GetValue(typeof(int));
            }
    
    public static void setval(string varname, int value)
            {
                typeof(PowerComINC).GetField(varname).SetValue(typeof(int), value);
            }
