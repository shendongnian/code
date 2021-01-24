    class BaseCache {}
    class NOT_DEFINED_CACHE : BaseCache {}
    class OTHER_CACHE : BaseCache {}
    
    var factory = new CacheFactory();
    OTHER_CACHE cache = factory.GetCache<OTHER_CACHE>(); // Oh dear, I wanted OTHER_CACHE but got NOT_DEFINED_CACHE!
