     BulkAllObservable<MenuForElasticSearch> bulk = client.BulkAll(mappedCollection, b => b
              .BufferToBulk((descriptor, list) =>
              {
                  foreach (var item in list)
                  {
                      descriptor.Index<MenuForElasticSearch>(bi => bi
                          .Index(index)
                          .Id(item.OptomasToolId)
                          .Document(item)
                      );
                  }
              }));
             bulk.Subscribe(new BulkAllObserver(
                 onError: (e) => {
                     // TO DO;
                 },
                 onCompleted: () => { 
                     // TO DO;
                 }
             ));
