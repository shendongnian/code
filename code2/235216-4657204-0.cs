    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(URL);
    HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
    Stream st = resp.GetResponseStream();
    StreamReader sr = new StreamReader(st);
    string buffer = sr.ReadToEnd();
    
    ArrayList uniqueMatches = new ArrayList();
    Match[] retArray = null;
    Regex RE = new Regex("name=\"(.*?)\" value=\"(.*?)\"", RegexOptions.Multiline);
    MatchCollection theMatches = RE.Matches(buffer);
    
    for (int counter = 0; counter < theMatches.Count; counter++)
    {
    //string[] tempSplit = theMatches[counter].Value.Split('"');
    
    Regex reName = new Regex("name=\"(.*?)\"");
    Match matchName = reName.Match(theMatches[counter].Value);
    
    Regex reValue = new Regex("value=\"(.*?)\"");
    Match matchValue = reValue.Match(theMatches[counter].Value);
    
    string[] dados = new string[2];
    dados[0] = matchName.Groups[1].ToString();
    dados[1] = matchValue.Groups[1].ToString();
    uniqueMatches.Add(dados);
    }
