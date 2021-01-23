    .WithFun(rec => ((Func<BloodGroup, int>)
        (i => 
            { 
                if(rec.IsDBNull(i)) return BloodGroup.NotSet;
                switch(i) 
                { 
                    case 1: 
                        return BloodGroup.OPositive;
                    case 2: 
                        return BloodGroup.ONegative;
                    // More cases...
                    default:
                        return BloodGroup.NotSet;
                }
            })).Invoke(rec.GetOrdinal("BloodGroup")))
