        private void MoveLayerUp()
        {
            if(Layers.SelectedItem != null)
            {
                int index = Layers.Items.IndexOf(Layers.SelectedItem);
                if (index > 0)
                {
                    var swap = Layers.Items[index - 1];
                    Layers.Items.RemoveAt(index - 1);
                    Layers.Items.Insert(index, swap);
                }
            }
        }
        private void MoveLayerDown()
        {
            if (Layers.SelectedItem != null)
            {
                int index = Layers.Items.IndexOf(Layers.SelectedItem);
                if (index < Layers.Items.Count-1)
                {
                    var swap = Layers.Items[index + 1];
                    Layers.Items.RemoveAt(index + 1);
                    Layers.Items.Insert(index, swap);
                }
            }
        }
