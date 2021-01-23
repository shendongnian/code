    public class BetterException : Exception
    {
        protected T GetValue<T>([CallerMemberNameAttribute] string propertyName = "")
        {
            return (T)Data[propertyName];
        }
    
        protected void SetValue<T>(T value, [CallerMemberNameAttribute] string propertyName = "")
        {
            Data[propertyName] = value;
        }
    }
