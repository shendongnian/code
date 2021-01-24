    private static void Write(Expression expression)
    {   Console.WriteLine(((MemberExpression)expression).Member.GetCustomAttribute<XmlElementAttribute>(false).ElementName);
    }
    private static void Main(string[] args)
    {
        Write(Expression.Property(Expression.New(typeof(Derived).GetConstructors()[0]), "Code"));
        Write(Expression.Property(Expression.TypeAs(Expression.New(typeof(Derived).GetConstructors()[0]), typeof(Base)), "Code"));
    }
