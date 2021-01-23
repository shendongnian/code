    using System;
    
    class Log
    {
        DateTime Date;
        String Type;
        String Description;
    
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
            switch (type)
            {
                case "A":
                    return new AParser();
                case "B":
                    return new BParser();
                case "C":
                    return new CParser();
                default:
                    throw new NotSupportedException();
            }
        }
    }
    
    abstract class LogParser { public abstract string Parse(string line);}
    
    class AParser : LogParser { public override string Parse(string line) { /* do parsing for A */ return string.Empty; } }
    class BParser : LogParser { public override string Parse(string line) { /* do parsing for B */ return string.Empty; } }
    class CParser : LogParser { public override string Parse(string line) { /* do parsing for C */ return string.Empty; } }
