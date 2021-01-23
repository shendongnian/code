    public class WeirdRequirements
    {
        int m_year, m_month, m_day;
        public delegate void MessagePrinter(string message);
        public MessagePrinter PrintMessage = Console.WriteLine;
    
        public WeirdRequirements()
        {
            m_year = 2000;
            m_month = 1;
            m_day = 1;
            PrintMessage("default");
        }
    
        public WeirdRequirements(int Month, int Day)
        {
            m_year = 2004;
            m_month = Month;
            m_day = Day;
            PrintMessage("int Month, int Day");
        }
    
        public WeirdRequirements(int Year, int Month, int Day)
        {
            m_year = Year;
            m_month = Month;
            m_day = Day;
            PrintMessage("int Year, int Month, int Day");
        }
    
        public void PrintValues()
        {
            PrintMessage(string.Format("Year={0} Month={1} Day={2}", m_year, m_month, m_day));
        }
    }
