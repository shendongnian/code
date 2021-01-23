            TextBox txt = new TextBox();
            Binding b = new Binding("Your Path Here");
            b.Source = "Your Source Here";
            
            b.ValidationRules.Add(new TextBoxEmptyRule());
            txt.SetBinding(TextBox.TextProperty, b);
            
           
