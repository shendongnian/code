    public class Person
    {
        public string FirstName { get; set; }
    }    
    static void Main(string[] args)
    {
        string propertyName = "FirstName";
        string methodName = "StartsWith";
        string keyword = "123";
        Type t = typeof(Person);
        ParameterExpression paramExp = Expression.Parameter(t, "p"); 
           // the parameter: p
        MemberExpression memberExp = Expression.MakeMemberAccess(paramExp, t.GetMember(propertyName).FirstOrDefault());
           // part of the body: p.FirstName
        MethodCallExpression callExp = Expression.Call(memberExp, typeof(string).GetMethod(methodName, new Type[] { typeof(string) }), Expression.Constant(keyword));
           // the body: p.FirstName.StartsWith("123")
        Expression<Func<Person, bool>> whereExp = Expression.Lambda<Func<Person, bool>>(callExp, paramExp);
        Expression<Func<Person, string>> selectExp = Expression.Lambda<Func<Person, string>>(memberExp, paramExp);
        Console.WriteLine(whereExp);   // p => p.FirstName.StartsWith("123")
        Console.WriteLine(selectExp);  // p => p.FirstName
        List<Person> people = new List<Person>();
        List<string> firstNames = people.Where(whereExp.Compile()).Select(selectExp.Compile()).ToList();
        Console.Read();
    } 
    
