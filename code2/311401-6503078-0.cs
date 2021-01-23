    //The method is used to serialize classes above, classes are passed as generic types
                    public void Serialization<T>(ref T engine)
                    {
                        try
                        {
                            Type genericType = typeof(T);
                            
                            if (typeof(MyClass1).Equals(genericType))
                            {
                                MyClass1 engineClass1 = engine as MyClass1;
                                //DO something for class 1
                            }
                            else if (typeof(MyClass2).Equals(genericType))
                            {
                                MyClass2 engineClass2 = engine as MyClass2;
                                //DO something for class 2
                            }
                            
                        }
                        catch (Exception e)
                        {
                            //If Exception occurs I would like to write values to passed class properties, how to do that?
                            Result = false;
                            EngineErrorMessage = e.Message;
                        }
                    }
