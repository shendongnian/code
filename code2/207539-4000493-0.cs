    var sections = jsonData["sections"].Select(obj => obj["section"]).Select(sectData =>
        {
            var section = new Section()
            {
                Name = HttpUtility.HtmlDecode(sectData["Term"].Value<string>().Replace("\"", `enter code here`"")),
                Tid = int.Parse(sectData["Term ID"].Value<string>().Replace(",", ""))
            };
            _sections.Add(section);
            return section;
        });
