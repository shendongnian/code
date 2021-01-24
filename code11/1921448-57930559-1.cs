    if(int.TryParse(minutes, out _minutes))
    {
    	if(_minutes >= 0 && _minutes <= 60)
    	{
    		listaMarcacoes[pos].Minutos = _minutes;	
    	}
    	else 
    	{
    		Console.Write("please choose a number between 0 and 60.");
    	}
    }
    else 
    {
    	Console.Write("is not an integer, please make sure you enter numbers only.");
    }
