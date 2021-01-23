    var document = XDocument.Load(@"C:\1.xml");
    var customers = document.Descendants("customer")
        .Select(arg =>
            new
            {
                Id = arg.Attribute("Id"),
                Name = arg.Descendants("name").Select(x => x.Value).Single()
            })
        .ToList();
    dataGridView1.DataSource = customers;
