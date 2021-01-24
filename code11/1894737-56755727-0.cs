    public class Combs
    {
        //build string list attribute
        public class ListAttribute : PXStringListAttribute
        {
            public ListAttribute() : base(new[]
                {
                    Pair(Comb, "Comb"),
                    Pair(Other, "Other")
                })
            { }
        }
    
        //declare constant values
        public const string Comb = "Comb";
        public const string Other = "Other";
    
        //build constant for values you want to compare in BQL
        public class other : PX.Data.BQL.BqlString.Constant<other>
        {
            public other() : base(Other) {; }
        }
    }
