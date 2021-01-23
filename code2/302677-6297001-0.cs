        public GameObject Clone()
        {
            var clone = new GameObject();
            foreach (var target in this.Initialize.GetInvocationList())
            {
                var mi = target.Method;
                var del = Delegate.CreateDelegate(
                              typeof(EventHandler<EventArgs>), clone, mi.Name);
                clone.Initialize += (EventHandler<EventArgs>)del;
            }
            return clone;
        }
