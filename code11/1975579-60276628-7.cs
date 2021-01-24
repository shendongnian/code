    public async Task<IActionResult> AddapAsync()
    {
      ViewBag.oid = oid;
      HttpResponseMessage Res = await client.GetAsync("https://localhost:44397/api/Values/Addap");
      if (Res.IsSuccessStatusCode)
      {
        List<Customers> user = JsonConvert.DeserializeObject<List<Customers>>(await Res.Content.ReadAsStringAsync());
        ViewBag.Customers = user;
        return View(user);
      }
      else
      {
         return RedirectToAction("Error", "Home");
      }
    }
