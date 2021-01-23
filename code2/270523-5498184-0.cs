    public class Calc
        {
            public Calc(string sourceName, string newString )
            {
                calcOperator = Operator.Concat;
                sourceType = dataType;
            }
    
            public Calc(int startindex, int  count )
            {
                calcOperator = Operator.PadLeft;
                sourceType = dataType;
            }
    }
