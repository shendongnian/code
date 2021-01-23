    public class Person : IModifiable
    {
        private bool _markDirty;
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                if (value != _Name)
                    _markDirty = true;
                _Name = value;
            }
        }
        public bool IsDirty()
        {
            return _markDirty;
        }
    }
    public interface IModifiable
    {
        public bool IsDirty();
    }
