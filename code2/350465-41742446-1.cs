c#
public static T Clone<T>(T original)
{
    T newObject = (T)Activator.CreateInstance(original.GetType());
    foreach (var originalProp in original.GetType().GetProperties())
    {
        originalProp.SetValue(newObject, originalProp.GetValue(original));
    }
    return newObject;
}
I hope this can help someone.
