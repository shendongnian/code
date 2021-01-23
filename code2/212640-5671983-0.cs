    public class GroupRightMap : ClassMap<GroupRight>
    {
        public GroupRightMap()
        {
            Table("GROUP_RIGHT_COMPOSITE");
            CompositeId()
                .KeyReference(x => x.Group, "GROUP_ID")
                .KeyReference(x => x.Right, "RIGHT_NUM");
            
            References(x => x.Group, "GROUP_ID")
                .Not.Update()
                .Not.Insert()
                .Cascade.All();
            References(x => x.Right, "RIGHT_NUM")
                .Not.Update()
                .Not.Insert()
                .Cascade.All();
            Map(x => x.RightValue, "RIGHT_VALUE").Not.Nullable();
        }
    }
