            static void Main(string[] args)
            {
                int[] classScores = new int[]{30,50,25,39,62};
                string[] studentNames = new string[]{"Jim","John","Mary","Peter","Sarah"};
                    Array.Sort(classScores, studentNames);   // sort both according to scores
                for (int i = 0; i < classScores.Length; i++)
                {
                    Console.WriteLine(classScores[i] + " " + studentNames[i]);
                }
            }
