    var operation = oContext.Load(oContext.GetUsersQuery());
    operation.Completed += (s, e) =>
      {
        var users = operation.Entities; // your users are here
      };
