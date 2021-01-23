    namespace SO.Enums
    {
        public enum SomeEnum
        {
            A,
            B,
            C,
            D
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                Type enumType = typeof(SomeEnum);
                var enumConstants =
                    Enum.GetValues(enumType).
                         Cast<SomeEnum>().
                         Select(x => new { Value = (int)x, Name = x.ToString() });
            }
        }
    }
