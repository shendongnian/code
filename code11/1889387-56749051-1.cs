    public class MainWindow: Gtk.Window
    {
        public MainWindow()
            :base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            this.DeleteEvent += (o, evt) => Gtk.Application.Quit();
            this.Shown += (o, args) => this.DisplayText();
        }
        void Build()
        {
            this.TextView = new Gtk.TextView();
            this.Add( this.TextView );
        }
        void DisplayText()
        {
            string[] ScoreBoard = new string[4];
            Gtk.TextIter Ti = this.TextView.Buffer.StartIter;
            string[] Temp = {
                "1\t2\t3\t4",
                "1\t2\t3\t4",
                "1\t2\t3\t4",
                "1\t2\t3\t4",
                "1\t2\t3\t4",
                "1\t2\t3\t4",
            };
            foreach (string Line in Temp)
            {
                ScoreBoard = Line.Split('\t');
                this.ActivelyWaitFor( 1000 );
                this.TextView.Buffer.Insert(ref Ti, ScoreBoard[0]);
                this.TextView.Buffer.Insert(ref Ti, "  |  ");
                this.TextView.Buffer.Insert(ref Ti, ScoreBoard[1]);
                this.TextView.Buffer.Insert(ref Ti, "\t");
                this.TextView.Buffer.Insert(ref Ti, ScoreBoard[2]);
                this.TextView.Buffer.Insert(ref Ti, "  |  ");
                this.TextView.Buffer.Insert(ref Ti, ScoreBoard[3]);
                this.TextView.Buffer.Insert(ref Ti, "\n");
            }
        }
        void ActivelyWaitFor(long targetMillis)
        {
            var stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();
            while( stopWatch.ElapsedMilliseconds < targetMillis ) {
                Gtk.Application.RunIteration();
            }
            stopWatch.Stop();
        }
        private Gtk.TextView TextView;
    }
