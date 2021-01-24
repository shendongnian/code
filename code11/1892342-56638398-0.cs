      int[,] slots = new int[4, 2];
            string appt_type;
            int counter = 0;//counts how many times the user had enter the letter "a"
            while (true)
            {
                Console.WriteLine("Please enter a or b");
                appt_type = Console.ReadLine();
                if (appt_type == "a")
                {
                    counter++;
                    for (int i = 0; i < slots.GetLength(0); i++)
                    {
                        for (int j = 0; j < slots.GetLength(1); j++)
                        {
                            slots[i, 0] = 1;
                            slots[counter - 1,1 ] = counter;//note:all of the elements that you want to change are in column 1 of the array
                        }
                    }
                    int q = 1;//the position of i in the array
                    foreach (int i in slots)
                    {
                        if(q%2!=1)
                            Console.WriteLine(i+" " );
                        else
                            Console.Write(i);
                        q++;
                    }
             
