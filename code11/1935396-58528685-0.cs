    var ans = searchPhrase.Length == 0
                ? (item.Description ?? String.Empty)
                : Regex.Replace((item.Description ?? String.Empty), // An item's Description could be NULL
                                Regex.Escape(searchPhrase),
                                "<span class='highlight'>$&</span>",
                                RegexOptions.IgnoreCase);
