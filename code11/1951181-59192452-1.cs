    public string EntityClassOpening(EntityType entity)
    {
        var baseTypeNames = new List<string>();
        baseTypeNames.Add(_typeMapper.GetTypeName(entity.BaseType));
    
        var hasId = entity.Properties.Any(e => e.Name == @"Id" && _typeMapper.UnderlyingClrType(e.TypeUsage.EdmType) == typeof(int));
    		
        if (hasId) {
            baseTypeNames.Add(@"IDbEntity");
        }
    
        return string.Format(
                CultureInfo.InvariantCulture,
                "{0} {1}partial class {2}{3}",
                Accessibility.ForType(entity),
                _code.SpaceAfter(_code.AbstractOption(entity)),
                _code.Escape(entity),
                _code.StringBefore(" : ", string.Join(", ", baseTypeNames.Where(e => !string.IsNullOrEmpty(e)))));
    }
