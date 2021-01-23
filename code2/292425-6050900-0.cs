    [HttpPost]
    public JsonResult Insert(string name, string vorname) // name&vorname filled by $_POST:)
    {
        var @new = new Person { Name = name, Vorname = vorname }
        this.repo.Insert(@new);
        return this.Json(new { success = true, newId = @new.Id });
    }
