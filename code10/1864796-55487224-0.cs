    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double TotalSales { get; set; }
        public string Comment
        {
            get
            {
                if (TotalSales > 10000)
                {
                    return "This employee is a good employee";
                }
                else
                {
                    return "This employee needs to improve his marketing skill";
                }
            }
        }
    }
