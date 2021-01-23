            static void Main( string[] args )
            {
                int numOFItems = 6;
                int population = 10;
    
                
                Genome[] gen = new Genome[population];
    
                Random rand = new Random ();
    
                for( int i = 0; i < population; i++ )
                {
    
                    int[] geneList = new int[numOFItems];
    
                    for( int j = 0; j < numOFItems; j++ )
                    {
                        geneList[j] = rand.Next (0, 4);
                    }
    
                    
                    gen[i] = new Genome (geneList);
    
                    Console.Out.Write ("\n" + gen[i].ToString ());
                }
                for( int i = 0; i < population; i++ )
                {
                    Console.Out.Write ("\n" + gen[i].ToString () + ";");
                }
                Console.ReadLine ();
            }
