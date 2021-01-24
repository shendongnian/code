    while (true)
    {
        if(vera == "Krščanstvo")
        {
            break;
        }
    
        if (vera == "Krscanstvo")
        {
            break;
        }
    
        if (vera == "Hinduizem")
        {
            break;
        }
    
        if (vera == "Islam")
        {
            break;
        }
    
        if (vera == "Budizem")
        {
                break;
        }
        
        Console.WriteLine("Vnesite ustrezno vero");
        vera = Console.ReadLine();
        
        prvacrkaVera = vera.Substring(0, 1);
        ostaloVera = vera.Substring(1, vera.Length - 1);
        
        prvacrkaVera = prvacrkaVera.ToUpper();
        ostaloVera = ostaloVera.ToLower();
    
        vera = prvacrkaVera + ostaloVera;
    }
