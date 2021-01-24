    var resp = response.Content.ReadAsStringAsync().Result;
    resp = resp.Trim("\"".ToCharArray());
    resp = resp.Replace("\\", "");
    ResPLP resplp = JsonConvert.DeserializeObject<ResPLP>(resp);
    codres = resplp.data;
