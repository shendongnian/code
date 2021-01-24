    int pheonixamount = int.Parse(Console.ReadLine());
    List<double> pheonix = new List<double>(pheonixamount); //Use pheonixamount instead of constant value
    List<double> resultList = new List<double>(pheonixamount); 
    for (int i = 0; i < pheonixamount; i++)
    {
        double bodylength = double.Parse(Console.ReadLine());
        double bodywidth = double.Parse(Console.ReadLine());
        double lengthof1wing = double.Parse(Console.ReadLine());
        //Best way to store three values is to create new class, instead of storing in three different variables
        pheonix.Add(bodylength);
        pheonix.Add(bodywidth);
        pheonix.Add(lengthof1wing);
        double result = Math.Pow(bodylength, 2) * (bodywidth + 2 * lengthof1wing);
        resultList(result);
    }
        //Print your pheonix values
       for (int i = 0; i < pheonixamount; i +=3)
       {
            //i, i+1, i+2 will give you bodyLength, bodyWidth, lengthof1wing respectively
            Console.Write(pheonix[i] +" "+ pheonix[i+1] +" "+ pheonix[i+2]);
       }
    
        //Print your result
       foreach (var item in resultList)
       {
            Console.Write(item);
       }
    }
