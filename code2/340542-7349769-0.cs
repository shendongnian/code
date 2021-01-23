        private static GirlingsWebEntities _entity;
        public GirlingsWebEntities ContextEntity
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    return _entity ?? (_entity = new GirlingsWebEntities());
                }
                else
                {
                    string sKey = "context_" + HttpContext.Current.GetHashCode().ToString("x");
                    if (!HttpContext.Current.Items.Contains(sKey))
                    {
                        HttpContext.Current.Items.Add(sKey, new GirlingsWebEntities());
                        ((GirlingsWebEntities)HttpContext.Current.Items[sKey]).ContextOptions.LazyLoadingEnabled = true;
                    }
                    return (GirlingsWebEntities)HttpContext.Current.Items[sKey];
                }
                
            }
        }
        public void CommitChanges()
        {
            ContextEntity.SaveChanges();
        }
    }
