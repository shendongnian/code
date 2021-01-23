    dynamic content = JsonConvert.DeserializeObject(requestContent);
    var contentCodes = ((IEnumerable<dynamic>)content).Where(p => p._id != null).Select(p=>p._id).ToList();
    List<string> codes = new List<string>();
    foreach (var code in contentCodes)
    {
        codes.Add(code?.ToString());
    }
