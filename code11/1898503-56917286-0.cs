    private async void ClassInfoButton_OnClicked(object sender, EventArgs e)
    {
        MyClass selectedClass = ClassesCollectionView.SelectedItem as MyClass;
        await Navigation.PushAsync(new ClassInfoPage(selectedClass));
    }
