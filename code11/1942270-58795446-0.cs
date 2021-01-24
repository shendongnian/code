    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        ProgB.Value = 0;
        ProgB.Maximum = ((App)App.Current)._Properties.Count() + 1;
        foreach (PropertyModel aProperty in ((App)App.Current)._Properties)
        {
            await Task.Run(() => _PropVM.Add(new PropertyViewModel(aProperty)));
            ProgB.Value++;
        }
        ProgB.Value = ProgB.Maximum;
    }
