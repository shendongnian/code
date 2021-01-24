	var gameUpdates = new List<object>
	{
		new ConsoleMessage { MessageContent = "Chimzee lost 10 HP!"},
		new HitpointsUpdate { MonsterID = 5, NewHP = 90 }
	};
	var json = JsonSerializer.Serialize(gameUpdates);
	Console.WriteLine(json);
[{"Type":"ConsoleMessage","MessageContent":"Chimzee lost 10 HP!"},{"Type":"HitpointsUpdate","MonsterID":5,"NewHP":90}]
