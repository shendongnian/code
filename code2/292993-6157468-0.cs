			var table = new DataTable();			
			//Create table columns
			_objectInstances.First().Columns.ToList().ForEach(a => table.Columns.Add(a, typeof(string)));
			//Create table rows
			_objectInstances.ToList().ForEach(i => table.Rows.Add(i.Dictionary.Values.ToArray()));
			table1.DataSource = table;
