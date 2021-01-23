    public static IEnumerable<ValueDescription> GetAllValuesAndDescriptions(Type t)
    {
      if (!t.IsEnum)
        throw new ArgumentException("t must be an enum type");
      return Enum.GetValues(t).Cast<Enum>().Select((e) => new ValueDescription() { Value = e, Description = e.Description() }).ToList();
    }
