    public class MySession : DynamicObject
    {
        //Why not use Dictionary class?
        private Hashtable _sessionVars = new Hashtable();
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            this[binder.Name] = value;
            return true;
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = this[binder.Name];
            return true;
        }
        //You can make it private so that users do not use strings directly.
        public object this[string key]
        {
            get
            {
                if (_sessionVars.ContainsKey(key))
                {
                    return this._sessionVars[key];
                }
                return null;
            }
            set
            {
                if (this._sessionVars.ContainsKey(key))
                {
                    this._sessionVars.Remove(key);
                }
                this._sessionVars[key] = value;
            }
        }
    }
