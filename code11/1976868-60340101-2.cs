    int counter2 = 0;
            int counter3 = 0;
            string[] Foods = { "Icecream", "Coffee", "Sweetpotato" };
            string[] Dislike = { "5", "10", "3" };
            int PercentageDisklikes = 100;
            int subNumber = 5;
            Console.WriteLine(Foods[0]);
            string Icecream = Console.ReadLine();
            Console.WriteLine("Do you like Ice cream? ");
            if (Icecream == "yes")
            {
                counter++;
                Console.WriteLine("Amount of ppl that like Ice cream: " + counter);
            }
            else if (Icecream == "no")
            {
                counter2++;
                Console.WriteLine("Amount of ppl that don't like Ice cream " + counter2);
                Console.WriteLine("Study shows 10% of people agree with you");
                PercentageDisklikes = PercentageDisklikes - subNumber;
                Console.WriteLine($"Our satisfaction = {PercentageDisklikes}%");
            }
            else if (Icecream == "maybe")
            {
                counter2++;
                counter3++;
                Console.WriteLine("Amount of ppl that don't like Ice cream : " + counter2);
                Console.WriteLine("Amount of ppl that maybe don't like Ice cream: " + counter3);
                PercentageDisklikes = PercentageDisklikes - subNumber;
                Console.WriteLine($"Our satisfaction = {PercentageDisklikes}%");
            }
            Console.WriteLine(Foods[1]);
            string Coffee = Console.ReadLine();
            Console.WriteLine("Do you like Coffee? ");
            if (Coffee == "yes")
            {
                counter++;
                Console.WriteLine("Amount of ppl that like Coffee: " + counter);
            }
            if (Coffee == "no")
            {
                counter2++;
                Console.WriteLine("Amount of ppl that don't like Coffee " + counter2);
                Console.WriteLine("Study shows 10% of people agree with you");
                PercentageDisklikes = PercentageDisklikes - subNumber;
                Console.WriteLine($"Our satisfaction = {PercentageDisklikes}%");
            }
            else if (Coffee == "maybe")
            {
                counter2++;
                counter3++;
                Console.WriteLine("Amount of ppl that don't like Coffee : " + counter2);
                Console.WriteLine("Amount of ppl that maybe don't like Coffee : " + counter3);
                PercentageDisklikes = PercentageDisklikes - subNumber;
                Console.WriteLine($"Our satisfaction = {PercentageDisklikes}%");
            }
