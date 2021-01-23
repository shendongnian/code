    public void myMethod(){
    int choice = int.Parse(Console.ReadLine());  // only 1 or 2 accepted.
    
    int maxNr = 10;
    int myValue = choice;
    
    //Only choice = 1 in displayed here.
    if(choice == 1){
       while(myValue <= maxNr){
         Console.WriteLine(myValue);
         myValue = myValue + 3;
       }
    }
    }
