    public bool DoSelectedRouter(StatusRouter statusRouter)
    {
        for (int i = 0; i < m_listPlatforms.Count; i++)
        {
            if (m_listPlatforms[i].IsCheked)
            {
                switch(statusRouter)
                {
                   case StatusRouter.Stop:
                     m_listPlatforms[i].Stop();
                     break;
                   case StatusRouter.Resume:
                     m_listPlatforms[i].Resume();
                     break;       
                     .......
                }
            }            
        }
        return false;
    }
