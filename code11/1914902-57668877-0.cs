                    Type tSource = item.SourceType;     //enum
                    Type tDest = item.DestinationType;  //enum
                    MethodInfo method = typeof(EnumConverters).GetMethod("GetEnumValues");
                    MethodInfo methodGenericSource = method.MakeGenericMethod(tSource);
                    object objEnumsSource = methodGenericSource.Invoke(null, null);
                    //var listObj = (IEnumerable<object>)objEnumsSource;//throw
                    var listInt = (IEnumerable<int>)objEnumsSource;
                    foreach (var i in listInt)
                    {
                        if (!Enum.IsDefined(tSource, i))
                            throw new ApplicationException($"!Enum.IsDefined({tSource.FullName}, {i})");
                        var o = Enum.ToObject(tSource, i);
                        var e = Convert.ChangeType(o, tSource);
                    }
                    
