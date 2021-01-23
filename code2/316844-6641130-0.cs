    public void SetSelectedRoutersStatus(StatusRouter status)
    {
        foreach(var router in GetCheckedRouters())
        {
            SetRouterStatus(router);
        }
    }
    
    IEnumerable<Router> GetCheckedRouters()
    {
        return m_listPlatforms.Where(router=>router.Checked);
    }
    
    void SetRouterStatus(Router router,StatusRouter status)
    {
         switch(status)
         {
             case(StatusRouter.Stop):
             {
                    router.Stop();
                    break;
             }
             case(StatusRouter.Start):
             {
                    router.Start();
                    break;
             }
             case(StatusRouter.Suspend):
             {
                    router.Suspend();
                    break;
             }
             case(StatusRouter.Resume):
             {
                    router.Resume();
                    break;
             }
             default:
               throw new NotSupportedException("Invalid StatusRouter");
         }
    }
