    var ints = strings.Select(str => {
                                 int value;
                                 bool success = int.TryParse(str, out value);
                                 return new { value, success };
                             })
                      .Where(pair => pair.success)
                      .Select(pair => pair.value);
