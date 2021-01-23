    if (template == System.IO.Path.GetFullPath(template))
    {
        ; //template is full path including volume or full UNC path
    }
    else
    {
        if (useCurrentPathAndVolume)
            template = System.IO.Path.GetFullPath(template);
        else
            template = Assembly.GetExecutingAssembly().Location
    }
