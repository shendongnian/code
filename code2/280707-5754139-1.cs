    string selectedValue =  DropDownList1.SelectedValue.ToString(); // cache it!
    var q = from c in xmlDoc.Descendants("Images")
            where c.Element("PropertyId").Value.ToString() == selectedValue 
            select new
            {
                PhotoPath = c.Element("PhotoPath").Value         
            };
    GridView1.DataSource = q;
    GridView1.DataBind();
