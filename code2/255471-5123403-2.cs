        public static ConcurrentDictionary<Tuple<Type, string>, 
            Func<object, object[], object>> ReflectionCache
        {
            get
            {
                if (_ReflectionCache==null) {
                    _ReflectionCache = new ConcurrentDictionary<Tuple<Type, string>,
                      Func<object, object[], object>>();
                }
                return _ReflectionCache;
            }
        } private static ConcurrentDictionary<Tuple<Type, string>, 
             Func<object, object[], object>> _ReflectionCache = null;
        public static object GetCachedProperty(object obj, string name)
        {
            Func<object,object[],object> del;
            if (!ReflectionCache.TryGetValue(Tuple.Create<Type,string>(obj.GetType(),
              name), out del)) {
                MemberInfo memberInfo = 
                   (MemberInfo)obj.GetType().GetMember(name).GetValue(0);
                PropertyInfo prop = null;
                FieldInfo fld = null;
                            
                switch(memberInfo.MemberType) {
                case MemberTypes.Field:
                    fld = obj.GetType().GetField(name);
                    break;
                case MemberTypes.Property:
                    prop = obj.GetType().GetProperty(name);
                    break;
                }
                
                if (prop == null && fld == null)
                {
                    throw new Exception("No property or field named '" + name 
                     + "' could be found in the context parent.");
                }
                if (prop!=null) {
                    prop= obj.GetType().GetProperty(name);
                    del = prop.GetValue;
                } else {
                    fld = obj.GetType().GetField(name);
                    del = delegate(object cls,object[] index) {
                        return fld.GetValue(cls);
                    };
                }
                
                ReflectionCache[Tuple.Create<Type,string>(obj.GetType(),name)]=del;
            }
            return(del(obj,null));
        }
