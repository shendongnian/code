    IWebService service = ...
    service.Expect(s => s.IsUserInRoleWebService("user", "Role 1")).Return(true);
    EntitlementCache cache = ...
    cache.Service = service;
    
    bool result = cache.IsUserInRole("user", "Role 1");
    Assert.IsTrue(result, "user member of 'Role 1'");
