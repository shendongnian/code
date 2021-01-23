    /// <summary>
    /// Let anyone implement this interface.
    /// </summary>
    public interface IMyHandler
    {
        void Process(IProcessContext context, string line);
    }
    /// <summary>
    /// Context information
    /// </summary>
    public interface IProcessContext
    {
    }
    // Actual parser
    public class Parser
    {
        private Dictionary<char, IMyHandler> _handlers = new Dictionary<char, IMyHandler>();
        private IMyHandler _defaultHandler;
        public void Add(char controlCharacter, IMyHandler handler)
        {
            _handlers.Add(controlCharacter, handler);
        }
        private void Parse(TextReader reader)
        {
            StringBuilder scope = new StringBuilder();
            IProcessContext context = null; // create your context here.
            string line = reader.ReadLine();
            while (line != null)
            {
                IMyHandler handler = null;
                if (!_handlers.TryGetValue(line[0], out handler))
                    handler = _defaultHandler;
                handler.Process(context, line);
                line = reader.ReadLine();
            }
        }
    }
