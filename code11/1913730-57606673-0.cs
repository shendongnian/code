            public enum DAYS
            {
                sunday =1,
                monday =2,
                tuesday= 4
            }
            static void Main(string[] args)
            {
                DAYS days =  DAYS.sunday | DAYS.monday;
                int numDays = CountDays(days);
            }
            static int CountDays(DAYS days)
            {
                int number = 0;
                for(int i = 0; i < 32; i++)
                {
                    number += ((uint)days & (1 << i)) == 0 ? 0 : 1;
                }
                return number;
            }
