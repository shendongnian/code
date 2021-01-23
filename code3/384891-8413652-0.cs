    // invoking overload with two parameters
    MethodInfo mInfoMethod = typeof(Reflection.Test).GetMethod(
                                                       "methodname",
                                                       BindingFlags.Instance | BindingFlags.NonPublic,
                                                       Type.DefaultBinder,
                                                       new[] {typeof (int), typeof (int)},
                                                       null);
    mInfoMethod.Invoke(aTest, new object[] { 10 ,20});
    
