    public partial class Opcconnect : OPCServerClass
    {
        public Tuple<string, string> DataRead()
        {
            return new Tuple<string, string>("SJZ", "TEST");
        }
    }
