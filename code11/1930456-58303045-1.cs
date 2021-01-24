    private void ShrinkSlider_Completed(object sender, EventArgs e)
        {
            gridSlider.Height = 100;
        }
        private void ExpandSlider_Completed(object sender, EventArgs e)
        {
            Binding binding = new Binding();
            binding.Source = gridMain;
            binding.Path = new PropertyPath(Grid.ActualHeightProperty);
            gridSlider.SetBinding(Grid.HeightProperty, binding);
        }
