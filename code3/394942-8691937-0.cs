            var properties = new List<string>();
            foreach (var info in typeof(Car).GetProperties())
            {
                properties.Add(info.Name);
            }
            cbxSortPrimary.ItemsSource = properties;
