        public static void FireAndForget(this Form f, Delegate del)
        {
            IAsyncResult r = f.BeginInvoke(del);
            f.EndInvoke(r); 
        }
