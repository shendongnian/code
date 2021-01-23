    private static void OnHandleDrop(DragEventArgs e)
    {
        if (e.Data != null && e.Data.GetDataPresent("System.Windows.Controls.ListView"))
        {
            //var person = e.Data.GetData("myFormat") as PersonModel;
            //Gets the ItemsSource of the source ListView and removes the person
            var source = e.Data.GetData("System.Windows.Controls.ListView") as ListView;
            if (source != null)
            {
                var person = source.SelectedItem as PersonModel;
                ((ObservableCollection<PersonModel>)source.ItemsSource).Remove(person);
    
                //Gets the ItemsSource of the target ListView
                ((ObservableCollection<PersonModel>)(((ListView)e.Source).ItemsSource)).Add(person);
            }
        }
    }
