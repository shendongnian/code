    case EntityState.Modified:
        if (property.IsModified)
        {
            if(property.OriginalValue == null && property.CurrentValue == null)
              continue;
    
            if(property.OriginalValue == null ||
               property.CurrentValue == null ||
               !property.OriginalValue.Equals(property.CurrentValue))
            {
                auditEntry.OldValues[propertyName] = property.OriginalValue;
                auditEntry.NewValues[propertyName] = property.CurrentValue;
            }
