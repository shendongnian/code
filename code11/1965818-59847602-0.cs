    public static void FindSandy(params string[] ocean)
        {
            for (int i = 0; i < ocean.Length; i++)
            {
                if (ocean[i] == "Sandy")
                {
                    Console.WriteLine("We found Sandy on position {0}", i);
                    break;
                }
                else
                {
                    Console.WriteLine("He was not here");
                    break;
                }
            }
        }
