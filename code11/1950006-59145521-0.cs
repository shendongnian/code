    class Identity
        {
            public int id { get; set; }
            public DateTime QCTime { get; set; }
            public string PcName { get; set; }
            public string QCTimeForGroup
            {
                get
                {
                    if (QCTime.Millisecond <= 300)
                    {
                        return "SL1";
                    }
                    else if (QCTime.Millisecond > 300 && QCTime.Millisecond <= 400)
                    {
                        return "SL2";
                    }
                    else if (QCTime.Millisecond > 400 && QCTime.Millisecond <= 500)
                    {
                        return "SL3";
                    }
                    return "SL4";
                }
            }
        }
    private void button_Click(object sender, EventArgs e)
            {
                List<Identity> listOfIdentity = new List<Identity>()
                {
                   new Identity() {id= 2615,QCTime=DateTime.Parse("2019-11-22 16:03:22.550"),PcName="Test3"},                              
                   new Identity() {id= 2615,QCTime=DateTime.Parse("2019-11-22 16:03:22.300"), PcName="Test1"},                            
                   new Identity() {id= 2615,QCTime=DateTime.Parse("2019-11-22 16:03:22.350"), PcName="Test2"},
                   new Identity() {id= 2615,QCTime=DateTime.Parse("2019-11-22 16:03:22.400"), PcName="Test2"},
                   new Identity() {id= 2615,QCTime=DateTime.Parse("2019-11-22 16:03:22.200"), PcName="Test1"},
                   new Identity() {id= 2615,QCTime=DateTime.Parse("2019-11-22 16:03:22.500"), PcName="Test1"},
                   new Identity() {id= 2615,QCTime=DateTime.Parse("2019-11-22 16:03:22.250"), PcName="Test1"},
                   new Identity() {id= 2615,QCTime=DateTime.Parse("2019-11-22 16:03:22.450"), PcName="Test1"},
                   new Identity() {id= 2615,QCTime=DateTime.Parse("2019-11-22 16:03:22.150"), PcName="Test1"}              
                };
                List<Identity> sortedIdentity = listOfIdentity.OrderBy(x => x.QCTime).ThenBy(x => x.PcName).ToList(); // here i order by time and then pc name
    
                var items1 = listOfIdentity.OrderBy(x => x.QCTime).ThenBy(x => x.PcName).GroupBy(x => x.PcName).Select(grp => grp.ToList()).ToList(); //sub list create based with **Test1, Test2 & Test3** (3 sub lists)
                var items2 = listOfIdentity.OrderBy(x => x.QCTime).ThenBy(x => x.PcName).GroupBy(x => new { x.QCTime, x.PcName }).Select(grp => grp.ToList()).ToList(); //sub list create based with each time and pc name (9 sublists)
                var items3 = listOfIdentity.OrderBy(x => x.QCTime).ThenBy(x => x.PcName)
                            .GroupBy(x => new { x.QCTimeForGroup, x.PcName }).Select(grp 
                            => grp.ToList()).ToList(); 
            }
