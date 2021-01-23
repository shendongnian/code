    public static S EnableLazyLoading<S>(this S service, bool lazyLoad = true)
         where S : IBaseService
    {
         service.UnitOfWork.EnableLazyLoad(lazyLoad);
         return service;
    }
