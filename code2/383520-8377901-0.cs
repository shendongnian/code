    @using MvcApplication4.Helpers @* for ArrayComparer *@
    
    @functions {
        public static string Cycle(params string[] options)
        {
            if (!HttpContext.Current.Items.Contains("Html.Cycle"))
                HttpContext.Current.Items["Html.Cycle"] = new Dictionary<string[], int>(new ArrayComparer<string>());
            var dict = (Dictionary<string[], int>)HttpContext.Current.Items["Html.Cycle"];
            if (!dict.ContainsKey(options)) dict.Add(options, 0);
            int index = dict[options];
            dict[options] = (index + 1) % options.Length;
            return options[index];
        }
    }
