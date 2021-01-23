    var mapper = new ConventionModelMapper();
    var field = mapper.ModelInspector.GetType()
        .GetField( "isPersistentProperty", BindingFlags.NonPublic | BindingFlags.Instance );
    
    var ispp = (Func<MemberInfo, bool, bool>)field.GetValue( mapper.ModelInspector );
    mapper.IsPersistentProperty( ( mi, b ) => ispp( mi, b ) 
       && ( /*any conditions here*/ mi.Name != "SomeFiledName" ) );
