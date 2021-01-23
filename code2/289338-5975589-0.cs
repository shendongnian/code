        public object this[string key]
        {
            get
            {
                 PropertyInfo info = user.GetType().GetProperty(key);
                 if(info == null)
                    return null
                 return info.GetValue(user, null);
            }
            set
            {
                 PropertyInfo info = user.GetType().GetProperty(key);
                 if(info != null)
                    info.SetValue(user,value,null);
            }
        }
