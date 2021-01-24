            Dictionary<string, string> CsvExport;
            foreach(var o in scores)
            {   
            //note that checking the type for each object enables you to have heterogenous lists if you want
            var objectType= o.GetType();
            foreach(var p in objectType.GetProperties())
            {
                var propertyName = p.Name;
                CsvExport[propertyName] = p.GetValue(o).ToString();
            }
            }
