        System.Text.RegularExpressions.Regex bodyRegex = new System.Text.RegularExpressions.Regex(@"(<h1[^>]*>[\u0000-\uFFFF]+?</h1>)");
    System.Text.RegularExpressions.Match bodyMatch = bodyRegex.Match(line);
            if (bodyMatch.Success)
              {
               FileContent = bodyMatch.Result("$0");
               FileContent = (FileContent.Replace(@"<h1>", "")).Replace(@"</h1>", "");
    }
