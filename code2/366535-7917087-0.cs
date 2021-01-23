    public static S EnableLazyLoading<T, S>(this S service, bool lazyLoad = true)
         where S : IBaseService<T>
    {
         service.UnitOfWork.EnableLazyLoad(lazyLoad);
         return service;
    }
