    var tenantSettings = _repository1.GetTenant(tenantId);
    var accountCount = _repository2.GetAccount(tenantId);
    var userCount =  _repository3.GetUsers(source, int.Parse(tenantId));
    await Task.WhenAll(tenantSettings, accountCount, userCount);
    var TenantSettingsModel = MapTenant(accountCount.Result, userCount.Result, tenantSettings.Result);
