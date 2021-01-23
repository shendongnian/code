    class DatesTime
    {
        
        public static DateTime Substract(DateTime now, int hours,int minutes,int seconds)
        {
            TimeSpan T1 = new TimeSpan(hours, minutes, seconds);
            return now.Subtract(T1);
        }
                
        
        static void Main(string[] args)
        {
            Console.WriteLine(Substract(DateTime.Now, 36, 0, 0).ToString());
            
        }
    }
}
