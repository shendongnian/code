    class Program
    {
        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern int time(int* timer);
        static unsafe void Main(string[] args)
        {
            DateTime now = DateTime.Now;
            DateTime utc_now = DateTime.UtcNow;
            int time_t_msvcrt = time(null);
            int time_t_managed = (int)Math.Floor((now.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds);
            int time_t_managed_2 = (int)Math.Floor((utc_now - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds);
            Console.WriteLine(time_t_msvcrt == time_t_managed);
            Console.WriteLine(time_t_msvcrt == time_t_managed_2);
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime time_t_now = epoch.Add(TimeSpan.FromSeconds(time_t_msvcrt));
            long now_secs = now.Ticks / 10000000L;
            long utc_now_secs = utc_now.Ticks / 10000000L;
            long time_t_now_secs = time_t_now.Ticks / 10000000L;
            Console.WriteLine(time_t_now_secs == now_secs);
            Console.WriteLine(time_t_now_secs == utc_now_secs);
            Console.ReadLine();
        }
    }
