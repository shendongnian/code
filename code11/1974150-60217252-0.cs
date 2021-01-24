    public ActionResult doSomething(string jsonArray)
    {
        List<string> deserializedJson = getJson(jsonArray);
        if (deserializedJson.Count == 0)
        {
            TempData["Error"] = "You must select one or items for this type of request";
            return Redirect("Index");
        }
        //business as usual stuff here
    }
    private List<string> getJson(string jsonArray)
    {
        List<string> deserializedJson = JsonConvert.DeserializeObject<List<string>>(jsonArray);
        return deserializedJson;
    }
