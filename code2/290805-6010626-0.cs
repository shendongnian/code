    public void Fire(string name)
            {
                FieldInfo field = this.GetType().GetField(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
    
                if (field != null)
                {
                    Delegate method = field.GetValue(this) as Delegate;
    
                    if (method != null)
                    {
                        method.Method.Invoke(method.Target, new object[0]);
                    }
                }
            }
