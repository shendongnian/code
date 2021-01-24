    static void Main(string[] args) 
    { 
        Program obj = new Program();
        Console.WriteLine("Press 1 for PackMan 2 Ghost and 3 for AC FSM");
        string input = Console.ReadLine();
    
        Boolean exit= false;
    
        While(!exit){
            Switch (input)
            {
                case 1 :
                    obj.Packman();
                    break;
                case 2: 
                    break;
                case 3: 
                    break;
                case 4:
                    Exit= true
            }
        }
    }
 
