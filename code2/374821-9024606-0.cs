    public JsonResult GetRelatedWebObjectsByWebObject(Guid id, string relatedWebObjectTypes)
        {
            JsonResult result = new JsonResult();
            Guid webSiteId = db.WebObjects.Find(id).WebSiteId;
            
            List<string> relatedTypes = new List<string>(relatedWebObjectTypes.Split(','));
            var resultData = (from w in db.WebObjects
                              where w.Id == id
                              from rw in w.RelatedWebObjects
                              select rw).ToList();
            result.Data = resultData.Where(w => relatedTypes.Contains(w.GetType().BaseType.Name) == true).Select(w => new { Id = w.Id, Type = w.GetType().BaseType.Name }).ToList();//w.Id).Select(w => w.GetType().BaseType.Name).ToList();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
