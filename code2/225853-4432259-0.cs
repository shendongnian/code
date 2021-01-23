    using System;
    using System.Text;
    public class RandomStringGenerator
    {
        readonly Random random;
        public RandomStringGenerator()
        {
            random = new Random();
        }
        public string Generate(int length)
        {
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException("length");
            }
            var stringBuilder = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                char ch = (char)random.Next(0,255 );
                stringBuilder.Append(ch);
            }
            return stringBuilder.ToString();
        }
       
    }
