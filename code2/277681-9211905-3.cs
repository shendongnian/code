        /// <summary>
        /// Create DataTemplate
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private DataTemplate SetTemplete(int i)
        {
            DataTemplate template = new DataTemplate();
            //set stack panel 
            FrameworkElementFactory sp = new FrameworkElementFactory(typeof(StackPanel));
            sp.Name = "spBind";
            sp.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);
            //set textblock
            FrameworkElementFactory tb = new FrameworkElementFactory(typeof(TextBlock));
            sp.Name = "tbBind";
            Binding b = new Binding();
            string ito = "[" + i.ToString() + "]";  // bind by index
            b.Path = new PropertyPath(ito);
            tb.SetBinding(TextBlock.TextProperty, b);
            sp.AppendChild(tb);
            //set the visual tree of the data template 
            template.VisualTree = sp;
            return template;
        }
