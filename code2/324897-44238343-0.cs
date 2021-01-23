    private class XnaFriendlyResolver : DefaultContractResolver {
      protected override JsonContract CreateContract(Type objectType) {
        // Add additional types here such as Vector2/3 etc.
        if (objectType == typeof(Rectangle)) {
          return CreateObjectContract(objectType);
        }
        return base.CreateContract(objectType);
      }
    }
