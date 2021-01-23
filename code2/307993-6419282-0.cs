    using System;
    class Log
    {
        DateTime Date;
        String Type;
        String Description;
        Dictionary<string,LogParser> logDictionary;
        static Log()
        {
            logDictionary = new Dictionary<string,LogParser>;
            logDictionary.Add("A",new AParser());
            logDictionary.Add("B",new BParser());
            logDictionary.Add("C",new CParser());
        }
        public Log(String line)
        {
            String[] pieces = line.Split(' ');    
            this.Date = DateTime.Parse(pieces[0]);    
            this.Type = pieces[1];
            LogParser parser = GetParser(this.Type);
            this.Description = parser.Parse(pieces[2]);
        }
        static LogParser GetParser(string type)
        {
            return logDictionary<string,LogParser>(type);
        }
    }
    abstract class LogParser { public abstract string Parse(string line);}
    class AParser : LogParser { public override string Parse(string line) { /* do parsing for A */ return string.Empty; } }
    class BParser : LogParser { public override string Parse(string line) { /* do parsing for B */ return string.Empty; } }
    class CParser : LogParser { public override string Parse(string line) { /* do parsing for C */ return string.Empty; } }
