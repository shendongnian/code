    public class Colorizator : IOrganicEnvironment<Cell<YUV>, YUV>>
    {
       // normal code here
    }
    public class ColorizatorCommand : ICommand
    {
        private Colorizator _colorizator;
        public ColorizatorCommand(Colorizator colorizator)
        {
            _colorizator = colorizator;
        }
        public void Execute()
        {
            //use _colorizator here;
        }
    }
