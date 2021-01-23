    public class MyBOClass{
    
    public FillMethodX(int ID,[Optional, DefaultParameterValue(string.Empty)] string connString)
    {
        //test if connString is null 
        SetConnString(connString);
        FillMethodX(ID);
    };
