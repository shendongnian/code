    public bool DoActionSelectedRouter(StatusRouter action)
    {
        for (int i = 0; i < m_listPlatforms.Count; i++)
        {
            if (m_listPlatforms[i].IsCheked)
            {
                DoAction(m_listPlatforms[i], action);
            }
        }
        return false;
    }
    
    private void DoAction(Platform platform,StatusRouter  action)
    {
         switch(action){
             case(StatusRouter.Stop):
             {
                    platform.Stop();
                    break();
             }
             case(StatusRouter.Start):
             {
                    platform.Start();
                    break();
             }
             case(StatusRouter.Suspend):
             {
                    platform.Suspend();
                    break();
             }
             case(StatusRouter.Resume):
             {
                    platform.Resume();
                    break();
             }
         }
    }
