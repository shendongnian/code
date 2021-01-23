        class ConsoleLogger : System.IO.TextWriter {
            private System.IO.TextWriter oldOut;
            private Queue<string> log = new Queue<string>();
            private StringBuilder line = new StringBuilder();
            private object locker = new object();
            private int newline;
            private int logmax;
            public ConsoleLogger(int history) {
                logmax = history;
                oldOut = Console.Out;
                Console.SetOut(this);
            }
            public override Encoding Encoding {
                get { return oldOut.Encoding; }
            }
            public override void Write(char value) {
                oldOut.Write(value);
                lock (locker) {
                    if (value == '\r') newline++;
                    else if (value == '\n') {
                        log.Enqueue(line.ToString());
                        if (log.Count > logmax) log.Dequeue();
                        line.Length = newline = 0;
                    }
                    else {
                        for (; newline > 0; newline--) line.Append('\r');
                        line.Append(value);
                    }
                }
            }
        }
