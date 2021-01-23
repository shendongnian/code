    public class MyBOClass{
    
    public FillMethodX(int ID,[Optional] string connString)
    {
        //test if connString is null 
        SetConnString(connString);
        FillMethodX(ID);
    };
