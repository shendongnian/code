            Console.WriteLine("Enter a value between 1 and 100");
            var input = int.Parse(Console.ReadLine());
            int sum = 0;
            if (input<1 || input>100) {
                Console.WriteLine("Sorry, Try again");
            }
            else{
                while(input > 2){
                    input-=1;
                    sum+=input;
                 }
            }
            Console.WriteLine("Sum of values: " + sum);
