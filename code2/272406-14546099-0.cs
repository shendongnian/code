            // Example: Adding a converter to a column (C#)
            Style styleReading = new Style(typeof(TextBlock));
            Setter s = new Setter();
            s.Property = TextBlock.ForegroundProperty;
            Binding b = new Binding();
            b.RelativeSource = RelativeSource.Self;
            b.Path = new PropertyPath(TextBlock.TextProperty);
            b.Converter = new ReadingForegroundSetter();
            s.Value = b;
            styleReading.Setters.Add(s);
            col.ElementStyle = styleReading;
