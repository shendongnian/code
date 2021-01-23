        var captions = document.Descendants()
            .Select(arg => 
                new
                {
                    CaptionAttribute = arg.Attribute("Caption"),
                    Path = string.Join("/", arg.Ancestors().Reverse().Select(anc => anc.Name))
                })
            .Where(arg => arg.CaptionAttribute != null)
            .Select(arg => new { Caption = arg.CaptionAttribute.Value, arg.Path })
            .ToList();
