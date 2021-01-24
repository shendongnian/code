        ...
        this.BindingContext = ViewModel;
        ...
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //1.get the selected model, get the selected name
            Company item = e.SelectedItem as Company;
            string selectedName = item.name;
            //2.update the name property in the model you bind to the entry.
            ViewModel.name = selectedName;
            //3. call UpdateCompany
            ...
            db.Update(item);
        }
