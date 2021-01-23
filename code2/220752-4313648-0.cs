    var s =
        @"ABC at start of line or ABC here must be replaced but, <span id=""__publishingReusableFragment"" >ABC inside span must not be replaced with anything. Another ABC here </span> this ABC must also be replaced";
    var newS = string.Join("</span>",s.Split(new[] {"</span>"}, StringSplitOptions.None)
        .Select(t =>
            {
                var bits = t.Split(new[] {"<span"}, StringSplitOptions.None);
                bits[0] = bits[0].Replace("ABC","DEF");
                return string.Join("<span", bits);
            }));
