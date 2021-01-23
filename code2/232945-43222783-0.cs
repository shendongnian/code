    public class Program
    {
        public static void Main(string[] args)
        {
            Double days= 7;
            string s=DateTime.Now.AddDays(7).ToString("dd/MM/yyyy");  
            DateTime dt= OrderDeliveryDate(days);
            Console.WriteLine("dt"+dt.ToString("dd/MM/yyyy"));
            
            
        }
        
        public static DateTime OrderDeliveryDate(Double days)
        {
           
            Double count=0;
            for(int i=0;i<days;i++)
            {
                if(DateTime.Now.AddDays(i).DayOfWeek.ToString() == "Saturday")
                {
                   count= count+1;
                }
                else if(DateTime.Now.AddDays(i).DayOfWeek.ToString() == "Sunday")
                {
                    count=count+1;
                }
                
            }
            days=days+count;
            return DateTime.Now.AddDays(days);
        }
    }
