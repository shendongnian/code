        [HttpPost]
        public ActionResult LoadTerritoryManagers(int districtId)
        {
            var _TMS = (from c in SessionHandler.CurrentContext.ChannelGroups
                    join cgt in SessionHandler.CurrentContext.ChannelGroupTypes on c.ChannelGroupTypeId equals cgt.ChannelGroupTypeId
                    where cgt.Name == "Territory" && c.ParentChannelGroupId == districtId
                    select new TMManager(){ Id = c.ChannelGroupId, Name = c.Name }).OrderBy(m => m.Name);
            if (_TMS == null)
                return Json(null);
            List<TMManager> managers = (List<TMManager>)_TMS.ToList();
            return Json(managers);
        }
