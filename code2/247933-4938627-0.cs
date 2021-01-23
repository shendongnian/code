        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Click += new EventHandler(delegate { DoButtonProcessing(this, "EffectsList", null); });
            button2.Click += new EventHandler(delegate { DoButtonProcessing(this, "LayersList", null); });
            button3.Click += new EventHandler(delegate { DoButtonProcessing(this, null, "Effects"); });
            button4.Click += new EventHandler(delegate { DoButtonProcessing(this, null, "Layers"); });
        }
        void DoButtonProcessing(object sender, string list, string action)
        {
            ListBox control = (ListBox)ActiveForm[list]; //can be null here, but your source also allowed that so I assume it's just a snippit.
            control.Items.Add(((Button)sender).Name);
            var selectedItem = control.SelectedItem;
            if (selectedItem == null) return;
            Refresh = false;
            UpdateUI null;
            Refresh = true;
        }
