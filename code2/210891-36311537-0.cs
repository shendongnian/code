    ComboBox MarcadorNS = new ComboBox();
    MarcadorNS.Height = 30;
    MarcadorNS.Width = 150;
    MarcadorNS.SelectedValuePath = "Uid";
    foreach (var temporalItem in GetPredefinedKinds())
    {
        Image ImagenCombo = new Image();
        ImagenCombo.Source =
        new BitmapImage(new Uri(
           "Imagenes/Marcadores/" +
            temporalItem.Name.ToLower() + ".png", UriKind.Absolute));
        ImagenCombo.Height = 28;
        ImagenCombo.Width = 28;
        ImagenCombo.VerticalAlignment = VerticalAlignment.Top;
        ImagenCombo.HorizontalAlignment = HorizontalAlignment.Left;
        Label textoCombo = new Label();
        textoCombo.VerticalAlignment = VerticalAlignment.Top;
        textoCombo.HorizontalAlignment = HorizontalAlignment.Left;
        textoCombo.Content = BaseDatos.NombresDeMarcadores(temporalItem.ToString());
        Grid GridCombo = new Grid();
        GridCombo.Uid = ObtenerMarcador(temporalItem.ToString());
        StackPanel stackCombo = new StackPanel();
        stackCombo.Orientation = Orientation.Horizontal;
        stackCombo.Children.Add(ImagenCombo);
        stackCombo.Children.Add(textoCombo);
        GridCombo.Children.Add(stackCombo);
        MarcadorNS.Items.Add(GridCombo);`
