    public class Test
    {
        public static void SyncProductsByType<T>() where T : BaseProduct
        {
            // this method is a simple wrapper with constraint
            SyncProductsByType(typeof(T));
        }
        public static void SyncProductsByType(Type type)
        {
            // decide whether this should public, private or internal
            if (type.BaseType != typeof(BaseProduct))
                throw new ArgumentOutOfRangeException(nameof(type));
            // do work
        }
    }
    public abstract class BaseProduct
    {
    }
    public class ApparelProduct : BaseProduct
    {
    }
