    private void Btnkast_Click(object sender, EventArgs e)
    {
        bool throws;
        int numberofthrows = 0;
    
        int dice;
        Random dicethrow = new Random();
        throws = int.TryParse(rtbantal.Text, out numberofthrows);
        List<int> list = new List<int>(); //I changed this to a list
        
        for (int i = 0; i < numberofthrows; i++)
        {
            
            dice = dicethrow.Next(1, 7);
            list.Add(dice); //add every roll to the array to check later the values if you want
            if (dice == 6)
            {
               //Print that you found 6 at the roll number list.Count
               Console.WriteLine("Found 6 at roll number: " + list.Count);
               break; //probably break the loop so you won't continue doing useless computation
            }
        }
    }
