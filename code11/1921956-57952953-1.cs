    static void Main(string[] args)
        {
            string[] c1 = { "Mik", "Don", "Sundar", "Neil" };
            string[] c2 = { "Kim", "Joy", "Fred", "Roi" };
            string[] c3 = { "Mae", "LA", "Ej", "Bob" };
            string[] c4 = { "Yin", "Yang", "Ching", "Chong" };
            for (int i = 0; i < 4; i++ )
            {
                string output = "";
                output += c1[i] + " "; 
                for (int j = 0; j < 4; j++)
                {
                    string output1 = output;
                    output1 += c2[j] + " ";
                    for (int k = 0; k < 4; k++)
                    {
                        string output2 = output1;
                        output2 += c3[k] + " ";
                        for (int l = 0; l < 4; l++)
                        {
                            string output3 = output2;
                            output3 += c4[l] + " ";
                            Console.WriteLine(output3 + "\n");
                        }
                    }
                }
            }
                Console.ReadKey();
        }
