    ...
    List<SomeClass> list = new List<SomeClass>();
    ...
    list.Add( new SomeClass { Predicate = d => d < 10, Result = SomeStruct.Foo } );
    list.Add( new SomeClass { Predicate = d => d > 90, Result = SomeStruct.Bar } );
    ...
    public IEnumerable<SomeStruct> GetResults(double input)
    { 
        foreach ( var item in list )
            if ( item.Predicate(input) )
                 yield return item.Result;
    }
