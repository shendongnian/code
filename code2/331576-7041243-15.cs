    public class DecimalToRomaNumeralParser : Expression
    {
        private List<Expression> expressionTree = new List<Expression>()
                                                      {
                                                          new MillionExpression(),
                                                          new HundredThousandExpression(),
                                                          new TenThousandExpression(),
                                                          new ThousandExpression(),
                                                          new HundredExpression(),
                                                          new TenExpression(),
                                                          new OneExpression()
                                                      };
        public override void Interpret(Context value)
        {
            foreach (Expression exp in expressionTree)
            {
                 exp.Interpret(value);
            }
        }
    }
