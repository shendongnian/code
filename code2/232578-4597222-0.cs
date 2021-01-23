    [TestMethod]
    public void CreateSetterFromGetter()
    {
        Action<Person, int> ageSetter = InitializeSet((Person p) => p.Age);
        Action<Person, string> nameSetter = InitializeSet((Person p) => p.Name);
    
        Person p1 = new Person();
        ageSetter(p1, 29);
        nameSetter(p1, "John");
    
        Assert.IsTrue(p1.Name == "John");
        Assert.IsTrue(p1.Age == 29);
    }
    
    public class Person { public int Age { get; set; } public string Name { get; set; } }
    
    public static Action<TContainer, TProperty> InitializeSet<TContainer, TProperty>(Expression<Func<TContainer, TProperty>> getter)
    {
        PropertyInfo propertyInfo = (getter.Body as MemberExpression).Member as PropertyInfo;
    
        ParameterExpression instance = Expression.Parameter(typeof(TContainer), "instance");
        ParameterExpression parameter = Expression.Parameter(typeof(TProperty), "param");
    
        return Expression.Lambda<Action<TContainer, TProperty>>(
            Expression.Call(instance, propertyInfo.GetSetMethod(), parameter),
            new ParameterExpression[] { instance, parameter }).Compile();
    }
