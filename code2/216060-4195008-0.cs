    public void FillListBox(ListBox listBox, XElement xml)
    {
        listBox.Items.Add("<" + xml.Name + ">");
        foreach (XNode node in xml.Nodes())
        {
            if (node is XElement)
                // sub-tag
                FillListBox(listBox, (XElement) node);
            else
                // piece of text
                listBox.Items.Add(node.ToString());
        }
        listBox.Items.Add("</" + xml.Name + ">");
    }
