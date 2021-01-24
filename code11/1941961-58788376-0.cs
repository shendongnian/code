    private void MealsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var meal = (Meals)((ListView)sender).SelectedItem;
        if (meal != null
        { 
            MahlzeitInfoText.Text = meal.Name;
        }
        else
        {
            MahlzeitInfoText.Text = "";
        }
    }
