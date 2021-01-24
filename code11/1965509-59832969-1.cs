C#
	var list = new List<dynamic>(){
		new {Team="team 1",MinSecondsPerGame=20},
		new {Team="team 1",MinSecondsPerGame=30},
		new {Team="team 2",MinSecondsPerGame=35},
		new {Team="team 2",MinSecondsPerGame=10},
		new {Team="team 3",MinSecondsPerGame=35},
		new {Team="team 3",MinSecondsPerGame=5},
	};
	var result = list.Select(s => 
		new {
			s.Team,
			s.MinSecondsPerGame,
			TeamMins=list.Where(_=>_.Team==s.Team).Sum(_=>_.MinSecondsPerGame)
		}
	);
	Console.WriteLine(result);
![](https://i.imgur.com/hmlTUMv.png)
