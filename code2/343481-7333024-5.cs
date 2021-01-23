    public class FileSizeParser : FileSizeExpression
    {
        private List<FileSizeExpression> expressionTree = new List<FileSizeExpression>()
                                                      {
                                                          new TbFileSizeExpression(),
                                                          new GbFileSizeExpression(),
                                                          new MbFileSizeExpression(),
                                                          new KbFileSizeExpression()
                                                      };
        public override void Interpret(FileSizeContext value)
        {
            foreach (FileSizeExpression exp in expressionTree)
            {
                exp.Interpret(value);
            }
        }
    }
