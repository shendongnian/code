            if (listBox2.SelectedValue != null)
            {
                string name = listBox2.SelectedItem.ToString();
                string value = textBox1.Text;
                if (!attributes_dict.ContainsKey(name))
                {
                    //attributes.Add(name, value);
                    attributes_dict[name] = value;
                    //UpdateXml();
                }
                else 
                {
                    attributes_dict.Remove(name);
                    attributes_dict.Add(name, value);
                    //UpdateXml();
                }
            }
        }
