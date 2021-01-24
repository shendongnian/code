	List<TypeA> typeAVariable = SomeMethod();
	List<TypeB> typeBVariable = AnotherMethod();
	var list = List<BaseClass>();
	list.AddRange(typeAVariable);
	list.AddRange(typeBVariable);
	foreach (var item in list)
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
