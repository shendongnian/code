    public class FileCleaner
    {
        public IEnumerable<string> GetOldFiles(string directoryName)
        {
            var limit = DateTime.Now.AddBusinessDays(-3);
            return Directory.GetFiles(directoryName).Where(file => File.GetCreationTime(file) < limit);
        }
        public void DeleteOldFiles(string directoryName)
        {
            foreach (var filename in GetOldFiles(directoryName))
            {
                File.Delete(filename);
            }
        }
    }
    public static class DateTimeExtensions
    {
        public static bool IsDusinessDay(this DateTime instance)
        {
            return instance.DayOfWeek != DayOfWeek.Saturday && instance.DayOfWeek != DayOfWeek.Sunday;
        }
        public static DateTime AddBusinessDays(this DateTime instance, int days)
        {
            var newDate = instance;
            while (days > 0)
            {
                newDate = newDate.AddDays(-1);
                if (newDate.IsBusinessDay())
                    --days;
            }
            return newDate;
        }
    }
