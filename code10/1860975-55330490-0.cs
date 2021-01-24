    public void EditListButton_Clicked(object sender, EventArgs args) 
    {
     ImageButton btn = sender as ImageButton;
     var item = btn.BindingContext as ShoppingList;
     if (item == null) return;
     await Navigation.PushAsync(new ShoppingListDetailPage(new ShoppingListDetailViewModel(item)));
    }
