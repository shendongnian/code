    public static void Main(string[] args)
        {
            Console.Out.Write("Saisir la taille : ");
            int taille = int.Parse(Console.In.ReadLine());
            for(int i = 0; i < taille; i++){
                for(int j = 0; j < taille; j++){
                  Console.Write("*");
                }
                Console.WriteLine("");
            } 
        }
