    public void FoodBox_Populating(object sender, PopulatingEventArgs e)
        {
            e.Cancel = true;            
            if (!testbit)
            {
                VM.LoadFoodSuggestions(FoodBox.SearchText);
            }
            else
            {
                testbit = false;
                FoodBox.PopulateComplete();
            } 
        }
