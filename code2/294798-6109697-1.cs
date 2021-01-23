    public abstract class CreditReportViewModel
    {
        public Person Person { get; set; }       
        public DateTime ReportDate { get; set; }
        public string PersonalAddress { get; set; }
        public string EmployerAddress { get; set; }
        public abstract float MakeSomeCalculation();
    }
    public class Derived : CreditReportViewModel
    {
        public override float MakeSomeCalculation()
        {
             // This method must be implemented in the derived class
        }
    }
