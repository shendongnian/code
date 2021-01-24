    class WikiTable
    {
        public async Task<IEnumerable<List<string>>> LoadWikiTable(string requestUriString)
        {
            HtmlDocument doc = new HtmlDocument();
            using (StreamReader reader = new StreamReader(WebRequest
                                                            .Create(requestUriString)
                                                            .GetResponse()
                                                            .GetResponseStream(),
                                                          Encoding.UTF8))
            {
                await Task.Run(() => 
                               doc.Load(reader.BaseStream /*, Encoding.UTF8*/));
            }
            return doc.DocumentNode
                      .SelectSingleNode("//table[@class='wikitable']")
                      .Descendants("tr")
                      .Select(x => x.ChildNodes
                                  .Select(c => c.InnerText.Trim())
                                  .Where(y => !string.IsNullOrWhiteSpace(y))
                                  .ToList()
                              );
        }
        public static string Table2String(IEnumerable<List<string>> table)
        {
            string Row2String(List<string> row) => string.Join("\t", row);
            return string.Join("\n", 
                               table.Select(row => Row2String(row)));
        }
    }
