        public void Form1_Method()
        {
            DataContainer.ValueToShare = 10;
        }
        public void Form2_Method()
        {
            MessageBox.Show(DataContainer.ValueToShare.ToString());
        }
