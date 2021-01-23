    void Main()
    {
       var fooParameter = Expression.Parameter(typeof(Foo));
       var valueParameter = Expression.Parameter(typeof(int));
       var propertyInfo = typeof(Foo).GetProperty("Bar");
       var assignment = Expression.Assign(Expression.MakeMemberAccess(fooParameter, propertyInfo), valueParameter);
       var assign = Expression.Lambda<Action<Foo, int>>(assignment, fooParameter, valueParameter);
       Action<Foo,int> fnSet = assign.Compile();
    
       var foo = new Foo();
       fnSet(foo, 3);
       foo.Bar.Dump();
    }
        
    class Foo {
        public int Bar { get; set; }
    }
