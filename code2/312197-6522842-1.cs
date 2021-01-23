    using(var b = new bench())
    {
         //stuff
         em1 = b.ElapsedMilliseconds;
    }
///
    class bench : Stopwatch, IDisposable
    {
        private static bool enabled = true;
        public static bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }
        private string func;
        /// <summary>
        /// Initializes a new instance of the <see cref="bench"/> class.
        /// </summary>
        public bench()
        {
            begin("", false, false);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="bench"/> class.
        /// </summary>
        /// <param name="showStack">if set to <c>true</c> [show stack].</param>
        public bench(bool showStack)
        {
            begin("", showStack, false);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="bench"/> class.
        /// </summary>
        /// <param name="showStack">if set to <c>true</c> [show stack].</param>
        /// <param name="showStart">if set to <c>true</c> [show start].</param>
        public bench(bool showStack, bool showStart)
        {
            begin("", showStack, showStart);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="bench"/> class.
        /// </summary>
        /// <param name="func">The func.</param>
        public bench(String func)
        {
            begin(func, false, false);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="bench"/> class.
        /// </summary>
        /// <param name="func">The func.</param>
        /// <param name="showStack">if set to <c>true</c> [show stack].</param>
        public bench(String func, bool showStack)
        {
            begin(func, showStack, false);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="bench"/> class.
        /// </summary>
        /// <param name="func">The func.</param>
        /// <param name="showStack">if set to <c>true</c> [show stack].</param>
        /// <param name="showStart">if set to <c>true</c> [show start].</param>
        public bench(String func, bool showStack, bool showStart)
        {
            begin(func, showStack, showStart);
        }
        /// <summary>
        /// Begins the specified func.
        /// </summary>
        /// <param name="func">The func.</param>
        /// <param name="showStack">if set to <c>true</c> [show stack].</param>
        /// <param name="showStart">if set to <c>true</c> [show start].</param>
        private void begin(String func, bool showStack, bool showStart)
        {
            if (bench.Enabled)
            { 
                this.func = func;
                if (showStack || showStart)
                    Debug.WriteLine("Start " + func);
                if (showStack)
                    Debug.WriteLine("Stack: " + Environment.StackTrace);
                this.Start();
            }
        }
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (bench.Enabled || this.IsRunning)
            {
                this.Stop();
                if (bench.Enabled)
                { 
                    Debug.WriteLine("Stop " + func + " " + Elapsed.TotalSeconds.ToString("0.#######") + " seconds");
                }
            }
        }
    }
