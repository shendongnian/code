    public static void CopyTo(EntityObject fromEntity, EntityObject toEntity)
    {
        foreach (var property in fromEntity.GetType().GetProperties())
        {
            if (property.GetSetMethod() == null)
                continue;
            var value = property.GetValue(fromEntity, null);
            property.SetValue(toEntity, value, null);
        }
    }
