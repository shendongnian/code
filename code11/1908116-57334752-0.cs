        int totalHours, memArraySize;
        int[] totalMembers;
        int[] memHours;
        for (int i = 0; i < 2; i++)
        {
            var stringNumbers = Console.ReadLine();
            var numbers = stringNumbers.Split(' ');
            int.TryParse(numbers[0], out totalHours);
            int.TryParse(numbers[1], out memArraySize);
            totalMembers = new int[memArraySize];
            memHours = new int[memArraySize];
            for (int j = 0; j < 2; j++)
            {
                totalMembers[j] = Convert.ToInt32(Console.ReadLine());
                memHours[i] = memHours[i] + totalMembers[j];
            }
    
        }
