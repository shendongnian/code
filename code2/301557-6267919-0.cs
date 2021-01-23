        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.SelectionMode = SelectionMode.MultiSimple;
            IEnumerable items = listBox1.Items;
            List<int> indices = new List<int>();
            
            foreach (var item in items)
            {
                string movieName = item as string;
                if ((!string.IsNullOrEmpty(movieName)) && movieName.Contains(searchString))
                {
                    indices.Add(listBox1.Items.IndexOf(item));
                }
            }
            indices.ForEach(index => listBox1.SelectedIndices.Add(index));
        }
