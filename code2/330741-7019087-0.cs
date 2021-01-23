    private static void DoSomething(object temp)
            {
                var typedTemp = CastToType(temp, new
                                {
                                    LoggedInUsername = "dummy",
                                    SomeCustomObject = "dummy",
                                    LastLoggedIn = DateTime.Now
                                });
    
                Console.WriteLine(typedTemp.LastLoggedIn);
            }
    
    private static T CastToType<T>(object obj, T type)
            {
                return (T) obj;
            }
