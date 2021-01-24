    [HttpPost]
    public async Task<IHttpActionResult> Receiving([FromBody]Document documentObject)
    {
         var content = await Request.Content.ReadAsStringAsync();
         var lst = content.Split('&').ToList();
         var json = "{";
         var lstSplit = lst[0].Split('=').ToList();
         json += ("\"" + lstSplit[0] + "\":\"" + lstSplit[0] + "\",");  //name
         lstSplit = lst[1].Split('=').ToList();
         json += ("\"" + lstSplit[0] + "\":" + lstSplit[0] ); // number
         json += "}";
         return Json(json ); // output => "{"name":"xxx","number":123}"
    }
