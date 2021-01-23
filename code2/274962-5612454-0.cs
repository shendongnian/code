    JsonObject body;
    string[] favoriteToys =
      (from child in (JsonValue)body.AsDynamic().Children
       where child.Value.AsDynamic().Name.ReadAs<string>(string.Empty).StartsWith("J")
       select child.Value.AsDynamic().BestToy.ReadAs<string>("No favorite toy"))
           .ToArray();
