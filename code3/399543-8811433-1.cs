    this.Editors
        .If(e => e.Accessor.PropertyType.IsEnum)
        .BuildBy(er =>
        {
            var tag = new HtmlTag("select");
            var enumValues = Enum.GetValues(er.Accessor.PropertyType);
            foreach (var enumValue in enumValues)
            {
                tag.Children.Add(new HtmlTag("option").Text(enumValue.ToString()));
            }
            return tag;
        });
