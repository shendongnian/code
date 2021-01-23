    public class TMManager
    {
        public int Id {get; set;}
        public string Name {get; set;}
    }
    
    public List<TMManager> LoadTerritoryManagers(int districtId)
    {
        var _TMS = (from c in SessionHandler.CurrentContext.ChannelGroups
                    join cgt in SessionHandler.CurrentContext.ChannelGroupTypes on c.ChannelGroupTypeId equals cgt.ChannelGroupTypeId
                    where cgt.Name == "Territory" && c.ParentChannelGroupId == districtId
                    select new TMManager(){ Id = c.ChannelGroupId, Name = c.Name }).OrderBy(m => m.Name);
    
        return (List<TMManager>)_TMS.ToList();
    }
