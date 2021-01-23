    public static class ObjectExtension
    {
            public static T Copy<T>(this T lObjSource)
            {
                T lObjCopy = (T)Activator.CreateInstance(typeof(T));
    
                foreach (PropertyInfo lObjCopyProperty in lObjCopy.GetType().GetProperties())
                {
                    lObjCopyProperty.SetValue
                    (
                        lObjCopy,
                        lObjSource.GetType().GetProperties().Where(x => x.Name == lObjCopyProperty.Name).FirstOrDefault().GetValue(lObjSource)
                    );
                }
    
                return lObjCopy;
            }
    }
