    private void FoodBox_MouseEnter(object sender, MouseEventArgs e)
        {            
            //FoodBox.PopulateComplete();  not working after acb loses focus...            
            testbit = true;
            FoodBox.IsDropDownOpen = true;        
        }
