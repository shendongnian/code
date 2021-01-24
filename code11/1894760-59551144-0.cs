        public string Url { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var content = $@"<a class='nav-link text-dark' href='/{Url}'>{Title}</a>";
            output.TagName = "li";
            output.Content.SetHtmlContent(content);
            output.Attributes.Add("class", "nav-item");
        }
