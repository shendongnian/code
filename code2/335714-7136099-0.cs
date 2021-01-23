    List<string> unusedProxies = new List<string>(Settings.Globals.Proxies);
    foreach (string proxy in Settings.Globals.UsedProxies)
    {
        unusedProxies.Remove(proxy);
    }
    int inx = rnd.Next(0, unusedProxies.Count);
    string proxy = unusedProxies[inx];
    Settings.Globals.UsedProxies.Add(proxy);
    return proxy;
  
