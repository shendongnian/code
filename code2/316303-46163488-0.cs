    public static void populateObject( object o)
        {
            Random r = new Random ();
            FieldInfo[] propertyInfo = o.GetType().GetFields();
            for (int i = 0; i < propertyInfo.Length; i++)
            {
                FieldInfo info = propertyInfo[i];
                
                string strt = info.FieldType.Name;
                Type t = info.FieldType;
                dynamic value = null;
                if (t == typeof(string) || t == typeof(String))
                {
                    value = "asdf";
                } else if(t == typeof(Int16) || t == typeof (Int32) || t == typeof(Int64)){
                    value = r.Next (999);
                    info.SetValue(o, value);
                }
                else if (t == typeof(Int16?) || t == typeof(Int32?) || t == typeof(Int64?) )
                {
                    Int16? v = (Int16)r.Next (999);
                    info.SetValue(o, v);
                }
                else if (t == typeof(DateTime) || t == typeof(DateTime?))
                {
                    value = DateTime.Now ;
                    info.SetValue(o, value);
                }
                else if (t == typeof(double) || t == typeof(float) || t == typeof(Double) )
                {
                    value = 17.2;
                    info.SetValue(o, value);
                }
                else if (t == typeof(char) || t == typeof(Char))
                {
                    value = 'a';
                    info.SetValue(o, value);
                } else {
                    //throw new NotImplementedException ("Tipo não implementado :" + t.ToString () );
                    object temp = info.GetValue(o);
                    if(temp == null)
                    {
                        temp = Activator.CreateInstance(t);
                        info.SetValue(o, temp);
                    }
                    populateObject(temp);
                }
                
                
            }
        }
