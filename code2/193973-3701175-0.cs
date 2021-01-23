            public static readonly DependencyProperty ValorRegistadoProperty = DependencyProperty.RegisterAttached(
            "ValorRegistado",
            typeof(string),
            typeof(CampoInfo), new PropertyMetadata(new PropertyChangedCallback((d, e) =>
            {
                UIElement uie = (UIElement)d;
                SetValorRegistado(uie, e.NewValue.ToString());
            })));
