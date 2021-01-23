    public class UserMap : ClassMap<User>
    {
        HasMany(x => x.Neighbourhood)
          .KeyColumn("User_id")
          .Not.LazyLoad().Cascade.SaveUpdate();
    }
    public class NeighborHoodMap : ClassMap<NeighborHood>
    {
        Table("Neighbourhood");
            CompositeId()
                .KeyReference(x => x.User, "User_id")
                .KeyReference(x => x.Place, "Place_id");
        
        Map(x => x.IsDefault).Not.Nullable();
        Map(x => x.Selected).Not.Nullable().Default("0");
    }
