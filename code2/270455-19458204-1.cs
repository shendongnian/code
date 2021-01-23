    HttpContext.Current.Request.GetType()
                    .GetProperties()
                    .Select(
                        a =>
                            new KeyValuePair<object, object>(a, HttpContext.Current.Request.GetType().GetProperty(a.GetType().Name)))
                    .ToList();
