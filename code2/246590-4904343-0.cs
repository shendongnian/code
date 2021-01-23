        DataGrid dataGrid = new DataGrid();
        dataGrid.Columns.Add(new DataGridTextColumn
        {
            Header = "Title",
            Binding = new Binding("title")
        });
        //all possible keywords
        var items = db.keywords.Select(k => new {Id = k.keyword_id, Name = k.name}).ToArray();
        //selected keywords ordered by id
        var selected = (from item in items
                       where keywordsListBox.SelectedItems.Contains(item.Name)
                       orderby item.Id
                       select item)
                       .ToArray();
        //create columns and bind them
        for(int i = 0; i < selected.Length; i++)
        {
            dataGrid.Columns.Add(new DataGridTextColumn
            {
                Header = selected[i].Name,
                Binding = new Binding("Keywords["+i+"]")
            });
        }
        var documents = (from d in db.documents
                         select new{ 
                            d.title, 
                            //All related keywords
                            Keywords = d.documents_keywords.Select(dk => 
                                           new { Id = dk.keywoard_id, Value = dk.value})
                                          .ToList()}) 
                        .AsEnumerable()
                        .Select(doc => new {
                            title = doc.title,
                            //Only selected keywords with default null values
                            Keywords = (from si in selected
                                       join k in doc.Keywords on si.Id equals k.Id into j
                                       from ji in j.DefaultIfEmpty(new { Id = si.Id, Value = null})
                                       orderby ji.Id
                                       select ji.Value)
                                       .ToArray()
                            });
       dataGrid.ItemsSource = documents.ToList();
