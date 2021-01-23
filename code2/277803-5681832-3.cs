        public static void SetPropertyThreadSafe<TControl>(this TControl self, Action<TControl> setter)
            where TControl : Control
        {
            if (self.InvokeRequired)
            {
                var invoker = (Action)(() => setter(self));
                self.Invoke(invoker);
            }
            else
            {
                setter(self);
            }
        }
        public static void Example()
        {
            var progBar = new ProgressBar();
            progBar.SetPropertyThreadSafe(p => p.Step = 3);
        }
