       //Read them in as strings if you want to check if they're "_blank_", convert them 
         later.
            string a = Console.ReadLine();
            string h = Console.ReadLine();
            string H = Console.ReadLine();
    
            double area = 0;
            double volume = 0;
        
            if(a == "") //If it's blank, no entry do this code. 
            {
                      //This is how I'd convert it, just a little less pretty for the sake
                      //of understanding for you. You'd need to do this in every if block.
                      double returnedDoubleh = ConvertToDouble(h);
                      double returnedDoubleH = ConvertToDouble(H);
                      //Have your formula if `a` is blank.
            }
            else if (h == "")
            {
                      double returnedDoubleA = ConvertToDouble(a);
                      double returnedDoubleH = ConvertToDouble(H);
                      //Have your formula if `h` is blank.
            }
            else if (H == "")
            {
                      double returnedDoubleA = ConvertToDouble(a);
                      double returnedDoubleh = ConvertToDouble(h);
                      //Have your formula if `H` is blank.
            }
            else //This is if none are blank OR More than one is blank which would crash if 
                    more than one is blank.. 
            {
                            area = Math.Pow(a, 2) * Math.Sqrt(3) / 4 + 3 * a * h / 2;
                            volume = Math.Pow(a, 2) * Math.Sqrt(3) * H / 12;        
            }
    
                           Console.WriteLine(volume);
                           Console.WriteLine(area);
                           Console.ReadLine();
