    FontProvider provider = new FontProvider();
            provider.AddFont(FontProgramFactory.CreateFont(@"C:\Windows\Fonts\lte50144.ttf"));
            SvgConverterProperties props = new SvgConverterProperties();
            props.SetCharset("Windows-1252");
            props.SetFontProvider(provider);
            byte[] byteArray = Encoding.GetEncoding(1252).GetBytes(svg);
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                Image image = SvgConverter.ConvertToImage(ms, pdf, props);
                image.SetFixedPosition(llx, lly);
                image.ScaleToFit(width, height);
                doc.Add(image);
            }
