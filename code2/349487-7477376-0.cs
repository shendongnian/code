    public class CommandContext
    {
        public Configuration Configuration { get; protected set; }
        public Request Request { get; protected set; }
        public CommandContext(Configuration configuiration, ...) { ... }
    }
...
    public Response Execute(Request request)
    {
        var context = new CommandContext(configuration, request);
        switch case request.processtype
        {
            case ProcessType.Import: return new Import().Execute(context);
            case ProcessType.Export: return new Export().Execute(context);
        }
    }
