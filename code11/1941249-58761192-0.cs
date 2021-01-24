            // for testing
            int a = 10; 
            int b = 20; 
            int x = a * b;
            Console.WriteLine("Done");
            long kPowerPrev = -999; // or whatever
            long kPowerCur = 0;
            int j = 0;
            while (true)
            {
                kPowerPrev = kPowerCur;
                // Don't use Math.Pow, it is slow, because of conversion to double.
                // so if you are raising it to an integer power, it is better to multiply by hand
                // The last time I measured, hand multiplication beat Math.Pow when your power is 5 or less
                j++;
                kPowerCur = j * j;
                if (kPowerCur >= x)
                {
                    Console.WriteLine(kPowerPrev);
                    break;
                }
            }
            Console.WriteLine("Done");
