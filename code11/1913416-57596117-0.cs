c#
var resultsFromDB = (from uastatus in _DataContext.UaStatusEntity
               where uastatus.IsUaComplete == false
               join client in _DataContext.Client on uastatus.ClientID equals client.ClientID
               where client.ClientStatus == "Active" && 
                     client.IsEnrolledNHCR.HasValue && 
                     client.IsEnrolledNHCR.Value
               join ps in _DataContext.ProductSelectionEntity on bill.ClientId equals ps.ClientID
               where bill.Id == ps.BillingId
               select new 
                          {
                               ClientId = client.ClientID,
                               ClientRelationship = client.ClientRelationship,
                               ClientName = client.ClientName,
                               EIN = client.EIN,     
                               ProductID = ps.ProductID,
          
                          }).ToList();
var results = (from value in resultsFromDB
              let ProductIDS = string.Join(",", resultsFromDB.Where(x => x.ClientId == value.ClientId ).Select(x => x.ProductID).ToList())
               select new PendingUA
                          {
                               ClientId = value.ClientID,
                               ClientRelationship = value.ClientRelationship,
                               ClientName = value.ClientName,
                               EIN = value.EIN,     
                               ProductIDS = ps.ProductIDS ,
          
                          }).Distinct().ToList();
 
for better performance, use linq group by 
