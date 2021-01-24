    int listamount; //stores the number
    if (int.TryParse(LStextbox.Text, out listamount) && LStextbox.Text.Length > 0)
    {
    	//int.tryparse converts the string into a integer
    	//text.lentgh > 0 makes sure the box will not be left blank
    
    }
    else
    {
    
    }
    int min = 0;
    int max = Int32.MaxValue; //i want to make the max an indefinite number, is that posible?
    
    int num = listamount;
    Random r = new Random();
    
    int[] ar;
    ar = new int[num];
    for (int i = 0; i <= num - 1; i++)
    {
    	ar[i] = r.Next(min, max);
    }
    foreach(int y in ar)
    	Console.WriteLine(y);
