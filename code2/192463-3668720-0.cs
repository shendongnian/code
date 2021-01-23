     class Program
    {
        static void Main(string[] args)
        {
            int j = 0 ;
            bool flag = false;
            string s = "myage = 400";
            
            char[]c = s.ToCharArray();
            for (int i = 0; i <= s.Length -1; i++)
            {
                if ((c[i] > '0') && (c[i] < '9'))
                {
                    flag = true;
                }
                if (flag)
                {
                    c[j++] = c[i];
                }
            }
            //for (; j < s.Length - 1; j++)
            //{
                c[j] = '\0';
            
            s = new string(c,0,j);
            int num = int.Parse(s);
            Console.WriteLine("{0}",num);
            Console.ReadKey();
        }
