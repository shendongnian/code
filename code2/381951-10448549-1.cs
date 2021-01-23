            Style style = new Style();
            Trigger t = new Trigger();
            style.TargetType = typeof(ComboBoxItem);
            t.Property = ListBoxItem.IsSelectedProperty;
            t.Value = true;
            Setter setter = new Setter(IsSelectedBehavior.IsSelectedProperty, true);
            t.Setters.Add(setter);
            style.Triggers.Add(t);
            cb.Resources.Add(typeof(ComboBoxItem), style);
