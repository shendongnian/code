        // Assuming a ComboBox in your UC named comboBox1.
        public object[] MyComboItems {
            get {
                var items = new object[comboBox1.Items.Count];
                for (int i = 0; i < comboBox1.Items.Count; i++) {
                    items[i] = comboBox1.Items[i];
                }
                return items;
            }
            set {
                comboBox1.Items.AddRange(value);
            }
        }
