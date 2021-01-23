    System.Threading.Tasks.Parallel
              .ForEach(urls, url => {
                 var result = processUrl(url);
                 lock(objects)
                 {
                      objects.Add(result);
                 }
               });
