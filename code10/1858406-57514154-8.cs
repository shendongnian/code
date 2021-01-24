    public class ResolvedArgument
    {
        public string Argument { get; }
        public string Parameter { get; }
        public ResolvedArgument(string argument, string parameter) =>
            (Argument, Parameter) = (argument, parameter);
        public override string ToString() =>
            $"'{Argument}' passed for '{Parameter}'";
    }
