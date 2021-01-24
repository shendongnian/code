    [BindProperty]
    public InputList Gender { get; set; } = new InputList(new[] { "Man", "Woman" });
    [BindProperty]
    public InputList Country { get; set; } = new InputList(new NameValueCollection()
    {
        { "", "--Select--" },
        { "CA", "Canada" },
        { "US", "USA" },
        { "MX", "Mexico" }
    });
