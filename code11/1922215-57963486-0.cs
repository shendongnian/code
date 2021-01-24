    //First query
    var carriers = _context.Carriers.Select(c => c.Carrier).ToList();
    //Second query
    var cust = _context.Custs.Select(c => c.Custs).ToList();
    
    carriers.ForEach(ca=>{
        //Object list inside your Carrier Model
        ca.ListOfCusts = new List<Carrier>();
        ca.ListOfCusts = cust.Where(cu=> cu.CarriersCustId.Equals(CarriersId)).FirstOrDefault();
    });
    //Get MoreLinq on NuGet package to use DistinctBy
    var result = carriers.DistinctBy(CarriersId).ToList();
     //On View nested foreach do get carries and cust
    <table>
      <tr>
        @foreach (var itemCarriers in Model)
        {
          <td>@itemCarriers.Id</td>
          <td>@itemCarriers.Name</td>
          <td>@itemCarriers.Price</td>
          <td>
            <table>
              <tr>
                @foreach (var itemCust in itemCarriers)
                {
                  <td>
                    @itemCust.Cust
                  </td>
                }
              </tr>
            </table>
          </td>
        }
    
      </tr>
    </table>
