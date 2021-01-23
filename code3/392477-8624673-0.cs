        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            // Find all TextBox  visual children named "txtAddress" starting with the datform control
            var txtAddressMatches = GetVisualChildWithName("txtAddress", datform).OfType<TextBox>();
            
            // Fina all ComboBox visual children named "Cm_Name" starting with the datform control
            var Cmb_NameMatches = GetVisualChildWithName("Cm_Name", datform).OfType<ComboBox>();
        }
        private IEnumerable<FrameworkElement> GetVisualChildWithName(string name, FrameworkElement element)
        {
            return GetVisualChildWithName(name, element, new List<FrameworkElement>());
        }
        private IEnumerable<FrameworkElement> GetVisualChildWithName(string name, FrameworkElement element, IEnumerable<FrameworkElement> matches) 
        {
            if (element == null)
            {
                return matches;
            }
            if (element.Name == name)
            {
                matches = matches.Concat(new []{element});
            }
            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(element); i++)
            {
                matches = matches.Concat(GetVisualChildWithName(name, VisualTreeHelper.GetChild(element, i) as FrameworkElement, new List<FrameworkElement>()));
            }
            return matches;
        }
