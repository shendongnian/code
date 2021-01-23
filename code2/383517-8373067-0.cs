    string key = "Cycle-"+String.Join("|", options);
    if (!html.ViewContext.HttpContext.Items(options))
         html.ViewContext.HttpContext.Items.Add(options, 0);
    int index = html.ViewContext.HttpContext.Items[options];
    html.ViewContext.HttpContext.Items[options] = (options.Length + 1) % options.Length;
    return options[index];
