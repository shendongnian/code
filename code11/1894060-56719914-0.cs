        private static bool AlreadyBound(TextBox box, string propertyName)
        {
            foreach (Binding binding in box.DataBindings)
            {
                if (binding.PropertyName == propertyName) return true; 
            }
            return false;
        }
