    interface IDivideLogic
    {
        int DivideNumber{get;set;}
    }
    
    class DivideLogic : IDivideLogic
    {
        public DivideLogic()
        {
            DivideNumber = 30;
        }
        public DivideLogic(int divideNumber)
        {
            DivideNumber = divideNumber;
        }
        public int DivideNumber{get;set;}
    }
    
    public class ClassA
    {
        public IDivideLogic DivideLogic {get;set;}
        public decimal MonthlyRate { get; set; }
        public virtual decimal DailyRate 
        { 
           get { return this.MonthlyRate / DivideLogic.DivideNumber; }
           private set { }
        }
    }
