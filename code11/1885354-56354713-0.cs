    var wi = GetWorkItemWithRelations(wiId);
    if (wi.Relations != null)
        {
            foreach (var wiLink in wi.Relations)
            Console.WriteLine("{0,-40}: {1}", wiLink.Rel, ExtractWiIdFromUrl(wiLink.Url));
        }
    static int ExtractWiIdFromUrl(string Url)
    {
        int id = -1;
        string splitStr = "_apis/wit/workItems/";
        if (Url.Contains(splitStr))
        {
            string [] strarr = Url.Split(new string[] { splitStr }, StringSplitOptions.RemoveEmptyEntries);
            if (strarr.Length == 2 && int.TryParse(strarr[1], out id))
                    return id;
        }
        return id;
    }
