        private void OwinSignIn(tblUser user)
        {
            var thumbPrint = Guid.NewGuid();
            var claims = new List<Claim>
            {
                ....
                new Claim(ClaimTypes.Thumbprint, thumbPrint.ToString())
            };
            MemoryCache.Default.Set(thumbPrint.ToString(), true, new CacheItemPolicy() { AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(60) });
    }
