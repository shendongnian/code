        public object AMethod(object param)
        {
            return DoWrapped(() =>
                          {
                              // Do stuff
                              object result = param;
                              return result;
                          });
        }
