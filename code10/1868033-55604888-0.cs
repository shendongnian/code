    using System;    
       
    namespace InterfaceDemo    
    {    
         //First Interface IDebitCard    
         interface IDebitCard    
         {     
           void CardNumber();    
         }    
       
         //Second Interface ICreditCard    
         interface ICreditCard    
         {    
           void CardNumber();    
         }    
       
         //Customer Class implements both the interfaces    
         class Customer: IDebitCard, ICreditCard    
         {   
        
           void IDebitCard.CardNumber()    
           {    
             Console.WriteLine("Debit Card Number: My Card Number is 12345XXXXX");    
           }    
              
           void ICreditCard.CardNumber()    
           {    
              Console.WriteLine("Credit Card Number: My Card Number is 98999XXXXX");    
           }    
              
           public void CardNumber()    
           {    
              Console.WriteLine("Customer ID Number: My ID Number is 54545XXXXX");    
           }    
         }    
       
         class Program    
         {    
           static void Main(string[] args)    
           {    
              Console.WriteLine("////////////////////- Implicit and Expliction Implementation -//////////////////// \n\n");    
              Customer customer = new Customer();    
              IDebitCard DebitCard = new Customer();    
              ICreditCard CreditCard = new Customer();    
       
              customer.CardNumber();    
              DebitCard.CardNumber();    
              CreditCard.CardNumber();    
       
              Console.ReadKey();    
           }    
         }    
    } 
    
