        public static class EstablecedorMargen { 
        public static Thickness GetMargen(DependencyObject objeto) => objeto != null ? (Thickness)objeto.GetValue(PropiedadMargen) : new Thickness();
        public static void SetMargen(DependencyObject objeto, Thickness value) => objeto?.SetValue(PropiedadMargen, value);
        public static readonly DependencyProperty PropiedadMargen 
            = DependencyProperty.RegisterAttached("Margen", typeof(Thickness), typeof(EstablecedorMargen), new UIPropertyMetadata(new Thickness(), Cambió));
        public static void Cambió(object sender, DependencyPropertyChangedEventArgs e) {
            if (!(sender is Panel panel)) return;
            panel.Loaded += new RoutedEventHandler(EstablecerMargenControlesHijos);
        } 
        public static void EstablecerMargenControlesHijos(object sender, RoutedEventArgs e) {
            if (!(sender is Panel panel)) return;
            foreach (var hijo in panel.Children) {
                if (!(hijo is FrameworkElement feHijo)) continue;
                feHijo.Margin = GetMargen(panel);
            }
        } 
    } 
