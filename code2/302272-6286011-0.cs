    public static class Constants
    {
        public const int CommandArgumentsSize = 3;
    }
    
    struct Command
    {
        byte opcode;
        byte arguments = new byte[Constants.CommandArgumentsSize];
    }
