    string otp=otp.getOtp();
    string input;
    int attemptsLeft=3;
 
    while(attemptsLeft>0)
    {
       input=Console.ReadLine();
       if(input==otp)
           return totalprice;
       else
       {
            Console.WriteLine("Incorrect OTP");  
            Console.WriteLine("Please Re Enter your Password {0} attempts left", attemptsLeft--);
       }
    
    }
    //Here you handle three unsuccessful attempts
