    var props = target.GetType()
                      .GetProperties()
                      .Select(p => new {
                          Name = p.Name,
                          Value = p.GetValue(target, null)
                      });
 ?
