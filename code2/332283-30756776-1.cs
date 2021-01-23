    /// <summary>
    /// The C#6 version
    /// </summary>
    public class TimerNicer : IDisposable {
        private Action OnElapsed { get; }
        [NotNull]
        private System.Timers.Timer Timer { get; } = new System.Timers.Timer { AutoReset = false, Interval = 1 };
        public TimerNicer(Action onElapsed) {
            this.OnElapsed = onElapsed ?? ( () => {
            } );
            this.Timer.Elapsed += (sender, args) => {
                this.Timer.Stop();    // Why not stop the timer here with this?
                try {
                    this.OnElapsed(); // do stuff here
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
