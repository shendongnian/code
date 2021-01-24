    static void Main(string[] args)
        {
            string[] c1 = { "Mik", "Don", "Sundar", "Neil" };
            string[] c2 = { "Kim", "Joy", "Fred", "Roi" };
            for (int i = 0; i <4; i++ )
            {
                string output = "";
                output += c1[i] + " "; 
                for (int j = 0; j < 4; j++)
                {
                    string output1 = output;
                    output1 += c2[j] + " ";
                    Console.WriteLine(output1 + "\n");
                }
            }
                Console.ReadKey();
        }
