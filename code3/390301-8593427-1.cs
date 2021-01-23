    void AddTraitButton_Click(object sender, RoutedEventArgs e)
    {
        if (this.CurrentCat != null)
        {
            this.CurrentCat.AddTrait(new Trait());
            this.CollectionViewSource.Refresh();
        }
    }
