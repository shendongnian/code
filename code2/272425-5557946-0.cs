    Assembly.GetExecutingAssembly().GetTypes().
      SelectMany(type => type.GetFields(BindingFlags.Public | BindingFlags.Static)).
      Where(fieldInfo => fieldInfo.FieldType.GetInterfaces().Contains(typeof(IUnit))).
      Any(fieldInfo =>
      {
        ((IUnit)fieldInfo.GetValue(null)).NameOfField= fieldInfo.Name;
        return false;
      });
