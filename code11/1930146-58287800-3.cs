	List<TypeA> typeAVariable = SomeMethod();
	List<TypeB> typeBVariable = AnotherMethod();
	var combinedList = List<BaseClass>();
	combinedList.AddRange(typeAVariable);
	combinedList.AddRange(typeBVariable);
	foreach (var item in combinedList)
	{
		if (item is TypeA typeAItem)
		{
			typeAItem.AnIntroperty;
		}
		else if (item is TypeB typeBItem)
		{
			typeBItem.AStringroperty;
		}
	}
