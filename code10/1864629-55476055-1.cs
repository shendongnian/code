    public partial class EntityDTO
    {
      public static Expression<Func<EntityDTO, bool>> HasType(EntityTypeDTO type)
      {
        return ed => ed.Type == type;
      }
      public static Expression<Func<EntityDTO, bool>> HasEntity(IEntityId entityId)
      {
          return ed => ed.EntityId.Id == entityId.Id;
      }
    }
