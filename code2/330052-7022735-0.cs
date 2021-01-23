        protected virtual void SetupViewControl()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(DoSetupViewControl));
            while (!mViewControlCreated)
            {
                // wait for view control created
                Thread.Sleep(100);
            }
        }
        private bool mViewControlCreated = false;
        protected virtual void DoSetupViewControl(object state)
        {
            mViewControl = ViewControlFactory.CreateViewControl();
            mViewControl.Dock = DockStyle.Fill;
            mViewControl.Initialize();
            this.Controls.Clear();
            this.Controls.Add(mViewControl);
            IntPtr wHnd = GetActiveWindow();
            IWin32Window owner = GetOwner(wHnd);
            mViewControlCreated = true;
            ShowDialog(owner);
            this.Dispose();
        }
        private IWin32Window GetOwner(IntPtr wHnd)
        {
            if (wHnd == IntPtr.Zero) return null;
            return new WindowWrapper(wHnd);
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern IntPtr GetActiveWindow();
        private class WindowWrapper : IWin32Window
        {
            private IntPtr mHwnd;
            public WindowWrapper(IntPtr handle)
            {
                mHwnd = handle;
            }
            public IntPtr Handle
            {
                get { return mHwnd; }
            }
        }
