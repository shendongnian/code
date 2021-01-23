    // using System.Data.Linq.Moles; 
    // CM is a namespace alias 
    var subsList = new List<CM.Subscription>{
      new CM.Subscription() { SubscriptionID = subId1 },
      new CM.Subscription() { SubscriptionID = subId2 },
      new CM.Subscription() { SubscriptionID = subId3 }};
    var subsTable = new MTable<CM.Subscription>();
    
    subsTable.Bind(subsList.AsQueryable());
