    using System;
    using System.Diagnostics;
    /// <summary>
    ///     Updated the code.
    /// </summary>
    public class NicerSystemTimer : IDisposable {
        public void Dispose() { using ( this.Timer ) { } }
        private System.Timers.Timer Timer { get; } = new System.Timers.Timer { AutoReset = false };
        /// <summary>
        /// Perform an <paramref name="action"/> after the given interval (in <paramref name="milliseconds"/>).
        /// </summary>
        /// <param name="action"></param>
        /// <param name="repeat">Perform the <paramref name="action"/> again. (Restarts the <see cref="Timer"/>.)</param>
        /// <param name="milliseconds"></param>
        public NicerSystemTimer( Action action, Boolean repeat, Double? milliseconds = null ) {
            if ( action == null ) {
                return;
            }
            this.Timer.Interval = milliseconds.GetValueOrDefault( 1 );
            this.Timer.Elapsed += ( sender, args ) => {
                try {
                    this.Timer.Stop();
                    action.Invoke();
                    if ( repeat ) {
                        this.Timer.Start();
                    }
                }
                catch ( Exception exception ) {
                    Debug.WriteLine( exception );
                }
            };
            this.Timer.Start();
        }
    }
    /// <summary>
    ///     Updated the code.
    /// </summary>
    public class NicerFormTimer : IDisposable {
        public void Dispose() { using ( this.Timer ) { } }
        private System.Windows.Forms.Timer Timer { get; }
        /// <summary>
        /// Perform an <paramref name="action"/> after the given interval (in <paramref name="milliseconds"/>).
        /// </summary>
        /// <param name="action"></param>
        /// <param name="repeat">Perform the <paramref name="action"/> again. (Restarts the <see cref="Timer"/>.)</param>
        /// <param name="milliseconds"></param>
        public NicerFormTimer( Action action, Boolean repeat, Int32? milliseconds = null ) {
            if ( action == null ) {
                return;
            }
            this.Timer = new System.Windows.Forms.Timer {
                Interval = milliseconds.GetValueOrDefault( 1 )
            };
            this.Timer.Tick += ( sender, args ) => {
                try {
                    this.Timer.Stop();
                    action.Invoke();
                    if ( repeat ) {
                        this.Timer.Start();
                    }
                }
                catch ( Exception exception ) {
                    Debug.WriteLine( exception );
                }
            };
            this.Timer.Start();
        }
    }
