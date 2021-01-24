    var minutes = Console.ReadLine(); 
    int _minutes = 0;
    
    if(int.TryParse(minutes, out _minutes))
    {
    	listaMarcacoes[pos].Minutos = _minutes;
    }
    else 
    {
    	Console.Write("is not an integer, please make sure you enter numbers only.");
    }
