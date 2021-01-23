    public class Prescription
    {
        public PDInt Fills;
    }
    public class PDInt 
    {
        public int Value;
    }
    Prescription p = new Prescription();
    foreach(var x in p.GetType().GetFields())
    {
        // var type = x.GetType();  // PDInt　or X //Fills
    }
