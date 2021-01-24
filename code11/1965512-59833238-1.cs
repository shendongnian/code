    var dataCollection = dataGridView1.Rows
                                      .Cast<DataGridViewRow>()
                                      .Select(r =>
                                         new 
                                         {
                                           Team = r.Cells["Team"].Value,
                                           MinSecondsPerGame = Convert.ToInt32(r.Cells["MinSecondsPerGame"].Value),
                                         }
                                         )
                                         .GroupBy(x => x.Team)
                                         .SelectMany(x => 
                                                    x.Select(c => 
                                                    new 
                                                    { 
                                                      c.Team, 
                                                      c.MinSecondsPerGame, 
                                                      TeamMins = x.Sum(v => v.MinSecondsPerGame) 
                                                    })); 
    dataGridView1.DataSource = dataCollection.ToList();
