    using System;
    using System.Text;
    class Program
    {
        public static void Main(string[] args)
        {
            string input = "mmmm gooood griiiiiiiiiieeeeeeefffff";
            var sb = new StringBuilder(input);
            char p2 = '\0';
            char p1 = '\0';
            int pos = 0, len=sb.Length;
            while (pos < len)
            {
                if (p2==p1) for (; pos<len && (sb[pos]==p2); len--)
                    sb.Remove(pos, 1);
                if (pos<len)
                {
                    p2=p1;
                    p1=sb[pos];
                    pos++;
                }
            }
            Console.WriteLine(sb);
        }
    }
