    public class SimFile
    {
        private List<Notechart> _notecharts = new List<Notechart>();
        public IEnumerable<Notechart> Notecharts 
        {
            get {return _notecharts.AsEnumerable<Notechart>();}
        }
        public class Notechart
        {
            public Notechart(SimFile parent)
            {
                this.Parent = parent;
            }
            private SimFile _parent = null;
            public SimFile Parent
            {
                get {return _parent;}
                set 
                {
                    if (value != null)
                    {
                        if (_parent != null)
                        {
                            _parent._notecharts.Remove(this);
                        }
                        _parent = value;
                        _parent._notecharts.Add(this);
                    }
                    else
                    {
                        throw new Exception("A Notechart MUST have a parent SimFile");
                    }
                }
            }
        }
    }
