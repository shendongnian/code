        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(comboBox1.SelectedItem.ToString())
            {
                case "Fruit":
                    FruitSelected();
                    break;
                case "Vegetables":
                    VegetableSelected();
                    break;
                default:
                    NoneSelected();
                    break;
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Similar code as above
        }
        protected void FruitSelected()
        {
            comboBox2.Items.Clear();
            comboBox2.Items.Add("Orange");
            comboBox2.Items.Add("Apple");
        }
        protected void VegetableSelected()
        {
            comboBox2.Items.Clear();
            comboBox2.Items.Add("Tomato");
            comboBox2.Items.Add("Cucumber");
        }
        protected void NoneSelected()
        {
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
        }
    }
