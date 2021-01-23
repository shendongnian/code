    public void yourMethod()
    {
        Random r = new Random(); 
         
        int sum=0;       
  
        for (int i = 0; i < 4; i++)         
        {             
            var roll = r.Next(1, 7);             
            sum += roll;         
        }         // sum should be the sum of the four dices 
        //a switch is faster for a larger amount of options
        switch(sum)
        {
            case 20:
            {
                Console.WriteLine("excellent");
            }
        }
        //Or use If else
        if(sum>=20)
        {
            Console.WriteLine("excellent");
        }
    }
