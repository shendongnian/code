var o = await client.GetOrderAsync(request);
return new Order {
    OrderDate = o.OrderDate,
    ...
    Shipments = o.Shipment_Order == null ? new Shipment[0]
        o.Shipment_Order.Select(sh => {
          var s = sh.ReceiverAddress_Shipment;
          var a = s.Address;
          return new Shipment {
            ShipmentID = sh.ShipmentID,
            ...
            Address = s == null ? 
                      null : 
                      new Address {
                        Street = a.Street
                        ...
                      }
          };
        }).ToArray()
};
or with [`??`](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-coalescing-operator) operator 
var o = await client.GetOrderAsync(request);
return new Order {
    OrderDate = o.OrderDate,
    ...
    Shipments = o.Shipment_Order?.Select(sh => {
        var s = sh.ReceiverAddress_Shipment;
        var a = s.Address;
        return new Shipment {
            ShipmentID = sh.ShipmentID,
            ...
            Address = s == null ? null : () => {
                return new Address {
                    Street = a.Street
                    ...
                };
            }()
          };
        }).ToArray() ?? new Shipment[0]
};
