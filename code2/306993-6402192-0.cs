    @{string westHand = "KQT5.KJ873..AJ52";
        var num = westHand.Length - 3;        
        char type = 'S'; //start with spades
        string[,] result = new string[num, 2];
        
        int counter = 0;
        foreach (string subString2 in westHand.Split('.'))
        {
            foreach (char card2 in subString2)
            {
                 @: [@type, @card2]
                result[counter, 0] = type.ToString();
                result[counter, 1] = card2.ToString();
                counter++;
            }
            switch (type)
            {
                case 'S': type = 'H'; break;
                case 'H': type = 'D'; break;
                case 'D': type = 'C'; break;
            }
        }       
    }
      <br /> You have @num cards. <br />        
      @for(var i = 0; i < num; i++)  
    { 
       @result[i,0] ; @result[i,1] ;<br /> 
    }
   
