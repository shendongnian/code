    private void listElement_ItemTapped(object sender, ItemTappedEventArgs e)
    {
         int SelectedMealGroupId = ((MealGroup)e.Item).Id; // You are sure of the type of e.Item !
         ....
         // You can call methods of the VM with :
         ((ViewModel)BindingContext).OnAddFood(SelectedMealGroupId); // Int parameter, not string
    }
