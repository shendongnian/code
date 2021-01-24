     private void InputNumber_TextChanged(object sender, TextChangedEventArgs e)
     {
      
         if(int.TryParse(InputNumber.Text, out int number))
            {
                OutputNumber.Text = number + (number % 2 == 0? " is an even number" : " is an odd number");
                                            //No need to write entire function we have modulo to check even odd  
    
            }
            if (InputNumber.Text == string.Empty)
            {
                OutputNumber.Clear();
            }
        }
