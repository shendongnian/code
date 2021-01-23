    Hashtable ht = new Hashtable();    
    ht.Add(1,"foo");
    ht.Add(2,"bar");    
    dataGridView1.DataSource = ht.Cast<DictionaryEntry>()
    							 .Select(x => new { Col1 = x.Key.ToString(), 
    												Col2 = x.Value.ToString() })
    							 .ToList();
