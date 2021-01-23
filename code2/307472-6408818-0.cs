    public class ClassA
    {
        public decimal MonthlyRate { get; set; }
        public int YourProperty {get; set;}
    
        public ClassA(int yourProperty)
        {
            YourProperty = yourProperty;
        }
        public virtual decimal DailyRate 
        { 
           get { return this.MonthlyRate / YourProperty; }
           private set { }
        }
    }
