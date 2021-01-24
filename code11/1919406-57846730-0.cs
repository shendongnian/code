      private void button7_Click(object sender, EventArgs e)
        {
            var list = new List<string>();
            foreach (var item in listBox1.Items)
            {
                list.Add(item.ToString());
                listBox2.Items.Add(item.ToString().Replace("_", " "));
            }
        }
