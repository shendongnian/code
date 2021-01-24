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
### Answer for your case
C#
public void TeamPoints()
{
    var list = dataGridView1.Rows.Cast<DataGridViewRow>().Select(r => 
        new {
            Team = r.Cells["Team"].Value,
            MinSecondsPerGame = Convert.ToInt32(r.Cells["MinSecondsPerGame"].Value),
        }
    );
    var result = list.Select(s =>
         new {
             s.Team,
             s.MinSecondsPerGame,
             TeamMins = list.Where(_ => _.Team == s.Team).Sum(_ => _.MinSecondsPerGame)
         }
    ).ToList();
    dataGridView1.DataSource = result;
}
![](https://i.imgur.com/QvfVtmG.png)
