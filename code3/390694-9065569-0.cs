         public static SiteMapNode ThisNode
        {
            get
            {
                if (_thisNode == null)
                {
                    if (SiteMap.CurrentNode != null)
                    {
                        return SiteMap.CurrentNode;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return _thisNode;
                }
            }
            set
            {
                _thisNode = value;
            }
        }
