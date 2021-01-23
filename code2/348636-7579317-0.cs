    var req = (HttpWebRequest)WebRequest.Create(someUrl);
    var sp = req.ServicePoint;
    var prop = sp.GetType().GetProperty("HttpBehaviour", BindingFlags.Instance | BindingFlags.NonPublic);
    prop.SetValue(sp, (byte)0, null);
    req.GetResponse().Close();
