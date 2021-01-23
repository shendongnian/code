            foreach (var item in list)
            {
                var cb = new CheckBox();
                dropDown.AddControl(cb);
                var b = new Binding("Text", item, "text");
                cb.HandleCreated += delegate(object sender, EventArgs e)
                {
                    cb.BindingContext = new BindingContext();
                    cb.DataBindings.Add(b);
                };
            }
