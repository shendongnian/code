    public static IEnumerable<Ret> Fn<Ret,Parm>(IList<Parm> P)  
            {
                var Results = new List<Ret>();
                foreach(Parm p in P)
                {
                    Results.Add(p.ToType());
                }
                return Results;
            }
