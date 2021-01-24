    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (names.Contains(comboBox1.SelectedItem.ToString())) //HERE I CAN CHECK IF THE NAME IN COMBO BOX MATCH WITH MY LIST OF STARTERS NAMES
        {
            XElement entreeXml = XElement.Load(@"c:\temp\entree.xml");
            var query = (from x in entreeXml.Element("entrees").Elements("entree")
                         where (string)x.Element("Nomentree") == comboBox1.SelectedItem.ToString()
			             select new
                         {
			                 Description = (string)x.Element("descentree"),
			                 Recipe = (string)x.Element("recette")
			             }).SingleOrDefault();
            
            if (query != null)
            {
                // Set listbox values to query.Description and query.Recipe
            }
        }
    }
