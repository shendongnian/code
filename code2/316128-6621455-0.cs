        private List<Binding> bindingCollection = new List<Binding>();
        private void ClearCurrentDatabindings()
        {
            if (bindingCollection.Count > 0)
            {
                foreach (Binding binding in bindingCollection)
                {
                    binding.Control.DataBindings.Clear();
                }
                bindingCollection.Clear();
            }
        }
        private void BindTextBox(object target, string targetProperty, 
               Control controlToBind )
        {
            Binding binding = new Binding("Text", target, property);
            control.DataBindings.Add(binding);
            bindingCollection.Add(binding);
        }
