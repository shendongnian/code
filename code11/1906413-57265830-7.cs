            ProductPalces test1 = new ProductPalces() {
                Name = "name1",
                Werk = "Werk1"
            };
            ProductPalces test2 = new ProductPalces()
            {
                Name = "name2",
                Werk = "Werk2"
            };
            WerkList.Add(test1);
            WerkList.Add(test2);
            comboBox1.DataSource = WerkList;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Werk";
