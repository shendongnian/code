    public class HttpSessionStateBaseProxy : HttpSessionStateBase
    {
        public virtual void SetItem(string key, object value)
        {
            base[key] = value;
        }
        public override object this[string name]
        {
            get
            {
                return base[name];
            }
            set
            {
                SetItem (name, value);
            }
        }
    }
