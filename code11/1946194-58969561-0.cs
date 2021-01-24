    public ActionResult AddNewSitemapElement(int? id)
        {
            if (id != null)
            {
                var mysitemap = db.Sitemaps.where(x => x.id == id.Value && !x.IsAdded).FirstOrDefault();
                if(mysitemap != null)
                {
                    mysitemap.IsAdded = true;
                    DB.SaveChanges();
                }
                return mysitemap;
            }
            return null;
        }
