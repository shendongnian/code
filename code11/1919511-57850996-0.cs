    public async Task<ActionResult> CreateOrEdit(int id = 0)
    {
        if (id==0)
        {
            return View(new Recipe());
        }
        using (var response = await GlobalVariablesUpdate.clientUp.GetAsync(id.ToString())
        {
            var temp = await response.Content.ReadAsStringAsync();
            var recipes = JsonConvert.DeserializeObject<IList<Recipe>>(temp);
            return View(recipes);
        }
    }
