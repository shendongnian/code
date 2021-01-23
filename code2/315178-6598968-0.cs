    private string GetTableName(Type type)
    {
      var tableAttribute = type.GetCustomAttributes(false).OfType<System.ComponentModel.DataAnnotations.TableAttribute>().FirstOrDefault();
      return tableAttribute == null ? type.Name : tableAttribute.Name;
    }
