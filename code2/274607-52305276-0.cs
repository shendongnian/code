    class Program
    {
        private class Parser
        {
            public string pname = "ParserPam"; 
            public enum pstate { rewind=-1, stdHeader, stBody, stFooter }
            public pstate state = pstate.stdHeader; 
            //Implement state transition logic as methods
            public void tick() => this.state = pstate.stBody;
            public void tock() => this.state = pstate.stFooter;
            public void rewind() => this.state = this.state - 1;
            public override string ToString()
            {
                return $"{this.pname} state: {this.state}";
            }
        }
        static void ParseFile(string filename)
        { 
            Parser fp = new Parser(); //This object tracks your method's state
            Console.WriteLine(fp); // "ParserPam state: stdHeader"
            if (fp.state == Parser.pstate.stdHeader)
            { 
                fp.tick(); // Transition
                // Do stuff
            }
            // Do more stuff
            Console.WriteLine(fp); // "ParserPam state: stBody"
            fp.tock();
            Console.WriteLine(fp); // "ParserPam state: stFooter"
            fp.rewind();
            Console.WriteLine(fp); // "ParserPam state: stBody"
        }
        static void Main(string[] args)
        {
            ParseFile( @"C:\Example" ); // Client call
        }
    }
