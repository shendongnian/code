    decimal answer_decimal; 
    while(!decimal.TryParse(answer, out answer_decimal)){
        Console.WriteLine("Value entered could not be converted.");
    }
    decimal compareValue = 45.2m;
    
            Console.WriteLine(answer_decimal);
            //prints 452
    
            if(Decimal.Compare(answer_decimal, compareValue) > 0){
                // stuff
            }
            else{
                // should enter here
            }
