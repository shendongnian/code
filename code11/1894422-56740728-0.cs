    public class MyBytes : List<byte>
    {
        public override string ToString()
        {
            return "These are my bytes:" 
                   + Environment.NewLine 
                   + string.Join(Environment.NewLine, this);
        }
    }
