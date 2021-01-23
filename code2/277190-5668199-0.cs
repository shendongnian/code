    public class PressViewModel
    {
    public int PressID{get;set;}
    public string Name{get;set;}
    public IEnumerable<VMPressPaperSpeed> PressPaperSpeeds{get;set;}
    }
    
    public class VMPressPaperSpeed{
    public int PressPaperSpeedID{get;set;}
    public int PressID{get;set;}
    public int PaperID{get;set;}
    public string PaperName{get;set;}// for view purpose 
    public int Speed{get;set;}//change data type for speed accordingly
    }
