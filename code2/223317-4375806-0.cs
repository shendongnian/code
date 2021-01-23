    class Customer
    {
        int waitingTime;         
        int arrivalTime;         
        int arrivalInterval; 
    
        // etc...
    }
    class ProcessCustomers
    {
        pubic void Arrive()
        {
            // etc...
        }
    }
    public void goButton_Click(object sender, EventArgs e)            
    {                
         Initialisers init = new Initialisers();                    
         ProcessCustomers CustomerQueue = new ProcessCustomers();                    
         CustomerQueue .Arrive();            
    }  
