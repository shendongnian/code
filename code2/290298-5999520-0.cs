    static class KernelExtensions
    {
        public static T GetDefault<T>(this IKernel kernel)
        {
            return kernel.Get<T>(m => m.Name == null);
        }
        public static T GetNamedOrDefault<T>(this IKernel kernel, string name)
        {
            T namedResult = kernel.TryGet<T>(name);
            if (namedResult != null)
                return namedResult;
            return kernel.GetDefault<T>();
        }
    }
