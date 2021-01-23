    public interface ISortableEntity
    {
        int ID { get; set; }
        int SortOrder { get; set; }
    }
    public static void MoveUp(ISortableEntity entity)
    {
        entity.SortOrder += 1;
    }
    public static void MoveDown(ISortableEntity entity)
    {
        entity.SortOrder -= 1;
    }
