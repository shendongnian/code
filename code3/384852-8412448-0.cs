         int timesContinued = 1;
            //Start lable
                    Start:
                    do
                    {
                        number = rndm.Ne
    
    xt(6) + 1;
                    Console.WriteLine(number);
                    Console.ReadKey();
        
                   if (number < 6)
                    {
                        loopcount++;
                    }
        
                } while (number != 6);
        
        
        
                AVGroll = AVGroll + loopcount;
                average = AVGroll / timesContinued;
        
                Console.WriteLine("The roll count is:");
                Console.WriteLine(loopcount);
                Console.WriteLine("average");
                Console.WriteLine(AVGroll);
                Console.WriteLine("press 1 to continue or 0 to exit");
        
        
        
        
                progcontinue = (int.Parse(Console.ReadLine()));
        
                if (progcontinue > 0)
                {
                    loopcount = 1;
                    timesContinued++;
                    goto Start;
        
                }
