            try
            {
                
                Type fromType = from.GetType();
                Type toType = to.GetType();
                PropertyInfo[] fromProps = fromType.GetProperties();
                PropertyInfo[] toProps = toType.GetProperties();
                for (int i = 0; i < fromProps.Length; i++)
                {
                    PropertyInfo fromProp = fromProps[i];
                    PropertyInfo toProp = toType.GetProperty(fromProp.Name);
                    if (toProp != null)
                    {
                        if (toProp.PropertyType.Module.ScopeName != "CommonLanguageRuntimeLibrary")
                        {
                            if (!toProp.PropertyType.IsArray)
                            {
                                ConstructorInfo ci = toProp.PropertyType.GetConstructor(new Type[0]);
                                if (ci != null)
                                {
                                    toProp.SetValue(to, ci.Invoke(null), null);
                                    toProp.SetValue(to, gestionRefelexion.CopyObject(fromProp.GetValue(from, null), toProp.GetValue(to, null)), null);
                                }
                            }
                            else
                            {
                                 
                                Type typeToArray = toProp.PropertyType.GetElementType();
                                Array fromArray = fromProp.GetValue(from, null) as Array;
                                toProp.SetValue(to, copyArray(fromArray, typeToArray), null);
                            }
                        }
                        else
                        {
                            toProp.SetValue(to, fromProp.GetValue(from, null), null);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return to;
        }
        public static Array copyArray(Array from, Type toType)
        {
            Array toArray =null;
            if (from != null)
            {
                toArray= Array.CreateInstance(toType, from.Length);
                for (int i = 0; i < from.Length; i++)
                {
                    ConstructorInfo ci = toType.GetConstructor(new Type[0]);
                    if (ci != null)
                    {
                        toArray.SetValue(ci.Invoke(null), i);
                        toArray.SetValue(gestionRefelexion.CopyObject(from.GetValue(i), toArray.GetValue(i)), i);
                    }
                }
            }
            return toArray;
            
        }
