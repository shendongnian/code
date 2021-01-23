    var utilClass = typeof(Utility); // the class with your admonish methods
	var admonishMethod = 
        (from m in utilClass.GetMethods()
        where m.IsStatic && m.Name == "Admonish"
        let parameter = m.GetParameters()[0]
        where parameter.ParameterType.IsAssignableFrom(list.GetType())
        select m).Single();
    admonishMethod.Invoke(null, new[]{list});
