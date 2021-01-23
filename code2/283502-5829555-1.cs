    public interface IAdult { }
    public interface IEducated { }
    public static class Extensions
    {
        // IAdult extensions
        public static void Age(this IAdult adult)
        {
            ...
        }
        public static void LicenseNo(this IAdult adult)
        {
            ...
        }
        // IEducated extensions
        public static void Read(this IEducated educated)
        {
            ...
        }
        public static void Write(this IEducated educated)
        {
            ...
        }
    }
