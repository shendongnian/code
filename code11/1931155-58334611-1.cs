    public class PointGroup
        {
            public int GroupID { get; set; }
    
            public Point Point1 { get; set; }
    
            public bool IsGrouped { get; set; }
        }
    for (int i = 0; i < coll.Count(); i++)
                {
    
                    PointGroup pg1 = coll[i];
                    if (!pg1.IsGrouped)
                    {
                        for (int j = 0; j < coll.Count(); j++)
                        {
                            PointGroup pg2 = coll[j];
                            if (pg1.Point1.Equals(pg2.Point1) && pg2.IsGrouped == false)
                            {
                                if (pg2.GroupID == j)
                                {
                                    pg2.GroupID = pg1.GroupID;
                                    pg2.IsGrouped = true;
                                }
                            }
                        }
    
                        pg1.IsGrouped = true;
                    }
                }
