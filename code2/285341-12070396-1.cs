    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Linq;
    public class Something
    {
        private readonly object _lock;
        private readonly List<string> _contents;
        public Something()
        {
            _lock = new object();
            _contents = new List<string>();
        }
        public Modifier StartModifying()
        {
            return new Modifier(this);
        }
        public class Modifier : IDisposable
        {
            private readonly Something _thing;
            public Modifier(Something thing)
            {
                _thing = thing;
                Monitor.Enter(Lock);
            }
            public void OneOfLotsOfDifferentOperations(string input)
            {
                DoSomethingWith(input);
            }
            private void DoSomethingWith(string input)
            {
                Contents.Add(input);
            }
            private List<string> Contents
            {
                get { return _thing._contents; }
            }
            private object Lock
            {
                get { return _thing._lock; }
            }
            public void Dispose()
            {
                Monitor.Exit(Lock);
            }
        }
    }
    public class Caller
    {
        public void Use(Something thing)
        {
            using (var modifier = thing.StartModifying())
            {
                modifier.OneOfLotsOfDifferentOperations("A");
                modifier.OneOfLotsOfDifferentOperations("B");
                modifier.OneOfLotsOfDifferentOperations("A");
                modifier.OneOfLotsOfDifferentOperations("A");
                modifier.OneOfLotsOfDifferentOperations("A");
            }
        }
    }
