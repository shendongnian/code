    class p
    {
        private p() { }
        public static p Version { get { return new p(); } }
        public static Expression<Func<Product, bool>> operator >(p left, Version version)
        {
            return product => product.Version.NumVersion > version.NumVersion;
        }
        ...
    }
    Where<Product>(p.Version > new Version(1,2,0,0))
