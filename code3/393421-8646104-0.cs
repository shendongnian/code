    string message1 = null;
    string message2 = null; 
    string message3 = null;
    
    void SetMessage(int i, string value)
    {
        if(i == 1)
            message1 = value;
        etc
    }
    
     for (int i = 1; i <=3; i++)
     {
       SetMessage(i, "blabla" + i.ToString());
     }
