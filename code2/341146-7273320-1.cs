        // Keep the observable collection as a field.
        private ObservableCollection<TracertNode> pTracertNodes;
        // Keep the instance of the running tracert as a field, we need it.
        private Tracert pTracert;
        public bool IsTracertRunning
        {
            get { return this.pTracert != null; }
        }
        public ObservableCollection<TracertNode> DoTrace(string hostOrIP, int maxHops, int timeOut)
        {
            // If we are not already running a tracert...
            if (this.pTracert == null)
            {
                // Clear or creates the list of tracert nodes.
                if (this.pTracertNodes == null)
                    this.pTracertNodes = new ObservableCollection<TracertNode>();
                else
                    this.pTracertNodes.Clear();
                var tracert = new Tracert();
                tracert.HostNameOrAddress = hostOrIP;
                tracert.MaxHops = maxHops;
                tracert.TimeOut = timeOut;
                tracert.NewNodeFound += delegate(Tracert sender, TracertNode newNode)
                {
                    // This method is called inside Tracert thread.
                    // We need to use synchronization context to execute this method in our main window thread.
                    SynchronizationContext.Current.Post(delegate(object state)
                    {
                        // This method is called inside window thread.
                        this.OnTracertNodeFound(this.pTracertNodes, newNode);
                    }, null);
                };
                tracert.TracertCompleted += delegate(object sender, EventArgs e)
                {
                    // This method is called inside Tracert thread.
                    // We need to use synchronization context to execute this method in our main window thread.
                    SynchronizationContext.Current.Post(delegate(object state)
                    {
                        // This method is called inside window thread.
                        this.OnTracertCompleted();
                    }, null);
                };
                tracert.Trace();
                this.pTracert = tracert;
            }
            return this.pTracertNodes;
        }
        protected virtual void OnTracertCompleted()
        {
            // Remove tracert object,
            // we need this to let the garbage collector being able to release that objects.
            // We need also to allow another traceroute since the previous one completed.
            this.pTracert = null;
            System.Windows.MessageBox.Show("TraceRoute completed!");
        }
        protected virtual void OnTracertNodeFound(ObservableCollection<TracertNode> collection, TracertNode newNode)
        {
            // Add our tracert node.
            collection.Add(newNode);
        }
