            var items = priceCalculatorContext.GetCustomers(company.CompanyNumber, 0);
            string filter_param = comboBox1.Text.ToLower();
            var filteredList = items.ToList().FindAll(x => x.FullCustomer.ToLower().Contains(filter_param));
            comboBox1.DisplayMember = "FullCustomer";
            comboBox1.ValueMember = "CustomerNumber";
            if (filteredList.Count() > 0)
                comboBox1.DataSource = filteredList;
            //set the datasource to items if the filter is empty, or the filtered list is empty
            if (String.IsNullOrWhiteSpace(filter_param) || filteredList.Count() == 0)
            {
                comboBox1.DataSource = items;
            }
