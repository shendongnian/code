    class Program
    {
        static void Main(string[] args)
        {
            var slots = new int[4, 2];
            while (true)
            {
                Console.Write("Do you want to proceed? [Y/N]");
                var choice = Console.ReadLine();
        
                if (!choice.Equals("y", StringComparison.CurrentCultureIgnoreCase))   
                    break;
        
                Console.WriteLine("Please enter a or b: ");
                var appt_type = Console.ReadLine();
        
                if (appt_type.Equals("a", StringComparison.CurrentCultureIgnoreCase))
                    slots = AssignScheduleA(slots);
        
                else if (appt_type.Equals("b", StringComparison.CurrentCultureIgnoreCase))
                    AssignScheduleB(slots);
        
                DisplaySlotsValue(slots);
            }
        }
        
        private static int[,] AssignScheduleA(int[,] slots)
        {
            if (slots[0,0] != 1)
            {
                for(int idx1 = 0; idx1 < slots.GetLength(0); idx1++)
                    slots[idx1, 0] = 1;
            }    
            
            for(int idx2 = 0; idx2 < slots.GetLength(0); idx2++)
            {
                if (slots[idx2, 1] == 0)
                {
                    slots[idx2, 1] = idx2 + 1;
                    break;
                }
            }
        
            return slots;
        }
        
        private static void AssignScheduleB(int[,] slots)
        {
            throw new NotImplementedException();    
        }
        
        private static void DisplaySlotsValue(int[,] slots)
        {
            for (int idx1 = 0; idx1 < slots.GetLength(0); idx1++)
                Console.Write(slots[idx1, 0]);
        
            Console.WriteLine();
        
            for (int idx2 = 0; idx2 < slots.GetLength(0); idx2++)
                Console.Write(slots[idx2, 1]);
        
            Console.WriteLine();
        }
    }
