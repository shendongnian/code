    using System.Linq;
    ...
    int n = 3;
    request.RequestedShipment.CustomsClearanceDetail.Commodities = Enumerable
      .Range(0, n) 
      .Select(index => new Commodity())
      .ToArray();
 
