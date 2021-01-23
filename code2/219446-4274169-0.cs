    public static void InvokeGeneric<T>(...) {
        MyEntityValidator<T> ev = new MyEntityValidator<T>(
            new EntityValidator());
    }
    ...
    typeof(ContainingType).GetMethod("InvokeGeneric").MakeGenericMethod(
        entry.Entity.GetType()).Invoke(null, args);
