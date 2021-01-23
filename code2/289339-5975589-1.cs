        public object this[string key]
        {
            get
            {
                 PropertyInfo info = this.GetType().GetProperty(key);
                 if(info == null)
                    return null
                 return info.GetValue(this, null);
            }
            set
            {
                 PropertyInfo info = this.GetType().GetProperty(key);
                 if(info != null)
                    info.SetValue(this,value,null);
            }
        }
