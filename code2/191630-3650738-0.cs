    public static TFooResult CreateFoo<TFooResult>()
    where TFooResult : FooBase//, new()
            {
                return (TFooResult)typeof(TFooResult).GetConstructor(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance, null, new Type[] {}, null).Invoke(new object[]{});
                //return new TFooResult();
            }
