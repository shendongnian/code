    public Road(string val)
    {
        Lane = val[0];
        Number = int.Parse(val.Substring(1));
     }
    public static explicit operator Road(string val)
    {
        return new Road(val);
    }
