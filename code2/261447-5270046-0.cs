    public static class PersonExtensions 
    {
    public static Person ChangeName(this Person p, String name)
    {
     p.Name = name;
     return p;
    }
