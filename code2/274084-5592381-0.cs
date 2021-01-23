    interface ISomething {
      IEnumerable<ISomething> Collection();
    }
    List<ISomething> PopulateItemRows() {
      var itemRows = new HashSet<ISomething>();
      var constructorInfos = Assembly.GetExecutingAssembly().GetTypes()
        .Where(
          type => type.IsClass
          && !type.IsAbstract
          && typeof(ISomething).IsAssignableFrom(type)
        )
        .Select(type => type.GetConstructor(Type.EmptyTypes))
        .Where(ci => ci != null);
      foreach (var constructorInfo in constructorInfos) {
        var something = (ISomething) constructorInfo.Invoke(null);
        itemRows.UnionWith(something.Collection());
      }
    }
