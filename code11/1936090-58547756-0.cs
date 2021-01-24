    private async Task calculateMacros()
    {
        var json = JsonConvert.SerializeObject(macroModel);
        var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        var response = await Http.PostAsync($"{navigationManager.BaseUri}api/Person/FromMacroCalculator", stringContent);
    }
