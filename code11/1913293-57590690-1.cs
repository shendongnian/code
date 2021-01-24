    private async Task<string> GenerateUrl(Model model)
    {
        var urlModel = GetUrlByOrganizationId(model.OrgId);
        var org = GetOrg(model.Id);
        model.Url = brand.Domain + org.Name;
        return Task.FromResult(model.Url);
    }
    private async string GenerateUrl(Model model)
    {
        var urlModel = GetUrlByOrganizationId(model.OrgId);
        var org = GetOrg(model.Id);
        model.Url = brand.Domain + org.Name;
        return model.Url;
    }
