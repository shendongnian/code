    using System;
    using System.Diagnostics;
    using System.Threading;
    using Timer = System.Windows.Forms.Timer;
    /// <summary>
    ///     Updated the code.
    /// </summary>
    public class NicerFormTimer : IDisposable {
        public void Dispose() {
            using ( this.Timer ) { }
        }
        private Boolean access { get; set; }
        private Timer Timer { get; }
        /// <summary>
        ///     Perform an <paramref name="action" /> after the given interval (in <paramref name="milliseconds" />).
        /// </summary>
        /// <param name="action"></param>
        /// <param name="repeat">Perform the <paramref name="action" /> again. (Restarts the <see cref="Timer" />.)</param>
        /// <param name="milliseconds"></param>
        public NicerFormTimer( Action action, Boolean repeat, Int32? milliseconds = null ) {
            if ( action == null ) {
                return;
            }
            this.Timer = new Timer {
                Interval = milliseconds.GetValueOrDefault( 1 )
            };
            this.Timer.Tick += ( sender, args ) => {
                try {
                    if ( Monitor.TryEnter( this.access ) ) {
                        this.access = true;
                        this.Timer.Stop();
                        action.Invoke();
                    }
                }
                catch ( Exception exception ) {
                    Debug.WriteLine( exception );
                }
                finally {
                    if ( this.access ) {
                        Monitor.Exit( this.access );
                        this.access = false;
                    }
                    if ( repeat ) {
                        this.Timer.Start();
                    }
                }
            };
            this.Timer.Start();
        }
    }
    /// <summary>
    ///     Updated the code.
    /// </summary>
    public class NicerSystemTimer : IDisposable {
        public void Dispose() {
            using ( this.Timer ) { }
        }
        private Boolean access { get; set; }
        private System.Timers.Timer Timer { get; }
        /// <summary>
        ///     Perform an <paramref name="action" /> after the given interval (in <paramref name="milliseconds" />).
        /// </summary>
        /// <param name="action"></param>
        /// <param name="repeat">Perform the <paramref name="action" /> again. (Restarts the <see cref="Timer" />.)</param>
        /// <param name="milliseconds"></param>
        public NicerSystemTimer( Action action, Boolean repeat, Double? milliseconds = null ) {
            if ( action == null ) {
                return;
            }
            this.access = false;
            this.Timer = new System.Timers.Timer {
                AutoReset = false, Interval = milliseconds.GetValueOrDefault( 1 )
            };
            this.Timer.Elapsed += ( sender, args ) => {
                try {
                    if ( Monitor.TryEnter( this.access ) ) {
                        this.access = true;
                        this.Timer.Stop();
                        action.Invoke();
                    }
                }
                catch ( Exception exception ) {
                    Debug.WriteLine( exception );
                }
                finally {
                    if ( this.access ) {
                        Monitor.Exit( this.access );
                        this.access = false;
                    }
                    if ( repeat ) {
                        this.Timer.Start();
                    }
                }
            };
            this.Timer.Start();
        }
    }
