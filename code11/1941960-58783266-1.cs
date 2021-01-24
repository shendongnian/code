        private void MealsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach(Meals iMeal in MealsList.SelectedItems)
            {
                    TextBox1.Text = iMeal.Name;
                    TextBox2.Text = iMeal.Calories.ToString();
                    TextBox3.Text = iMeal.Carbs.ToString();
                    TextBox4.Text = iMeal.Fats.ToString();
                    TextBox5.Text - iMeal.Proteins.ToString();
            }
        }
