    var identityMap1 = lstItems
      .SelectMany(item => item
         .Variants
         .Select(inner => new {
            SKU = inner.SKU,
            Pic = inner.Picture //TODO: Put the right value here: is it inner? item?
          }))
      .ToDictionary(item => item.SKU, item => item.Pic);
