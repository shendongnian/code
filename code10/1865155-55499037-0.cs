    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "a";
        var mailTo = MailTo;
        if (string.IsNullOrWhiteSpace(mailTo))
        {
            var content = await output.GetChildContentAsync();
            mailTo = content.GetContent();
        }
        var target = mailTo + "@" + EmailDomain;
        output.Attributes.SetAttribute("href", "mailto:" + target);
        output.Content.SetContent(target);
    }
