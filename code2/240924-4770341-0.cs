    public abstract class LinkBase
    {
        public abstract string Name { get; }
        protected abstract void OnClick(object sender, EventArgs eventArgs);
        //...
    }
    public class Link : LinkBase
    {
        public Link(string name, Action<object, EventArgs> onClick)
        {
            _name = Name;
            _onClick = onClick;
        }
        public override string Name
        {
            get { return _name; }
        }
        protected override void OnClick(object sender, EventArgs eventArgs)
        {
            if (_onClick != null)
            {
                _onClick(sender, eventArgs);
            }
        }
        private readonly string _name;
        private readonly Action<object, EventArgs> _onClick;
        
    }
