    List<Object> newObject = new List<Object> {
                new Object {
                      Name = value1,
                      ID = value2,
                      Date = value3,
                      Number = value4,
                      FilePaths = paths.Any() ? $"\"{string.Join(",", paths.ToList())}\"" : null;,
                      Messages = value6
                }
          };
