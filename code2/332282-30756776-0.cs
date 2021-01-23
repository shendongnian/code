    /// <summary>
    /// The C#6 version
    /// </summary>
    public class TimerNicer : IDisposable {
        private Action OnElasped { get; }
        [NotNull]
        private System.Timers.Timer Timer { get; } = new System.Timers.Timer { AutoReset = false, Interval = 1 };
        public TimerNicer( Action onElasped ) {
            this.OnElasped = onElasped ?? ( () => {
            } );
            this.Timer.Elapsed += (sender, args) => {
                this.Timer.Stop();    //Why not stop the timer here with this?
                try {
                    this.OnElasped(); //do stuff here
                }
                catch ( Exception exception ) {
                    Console.WriteLine( exception );
                }
                finally {
                    this.Timer.Start();
                }
            };
            this.Timer.Start();
        }
        public void Dispose() => this.Timer.Dispose();
    }
