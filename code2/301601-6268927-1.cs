    public class RetunType
            {
                public int a;
            }
    
            public class Input
            {
                public int x;
                public RetunType TotoAReturnType()
                {
                    return new RetunType() { a = this.x };
                }
            }
    
            public static IEnumerable<Ret> Fn<Ret, Parm>(IList<Parm> P) where Parm : Input  where Ret:RetunType
            {
                var Results = new List<Ret>();
                foreach (Parm p in P)
                {
                    Results.Add(p.TotoAReturnType());
                }
                return Results;
            }
