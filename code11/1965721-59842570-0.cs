    var dataNotInInfoTwo = InfoInOne.Select(x=>new {ID=x.IdInOne,Name=x.NameInOne})
                   .Except(InfoInTwo.Select(x=>new {ID=x.IdInTwo,Name=x.NameInTwo}));
	foreach(var item in dataNotInInfoTwo)
	{
			Console.WriteLine($"Data Not Found : ID : {item.ID}, Name:{item.Name}");
	}
