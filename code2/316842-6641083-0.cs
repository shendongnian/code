        public bool ActionSelectedRouter(Action<Platform> action)
        {
            for (int i = 0; i < m_listPlatforms.Count; i++)
            {
                if (m_listPlatforms[i].IsCheked)
                    action(m_listPlatforms[i]);
            }
            return false;            
        }
