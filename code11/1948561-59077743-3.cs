    public static void Main(string[] args)
        {
            char[] chars = { '&', `#`, `*`, '@' };
            int characterIndex;
            Console.Out.Write("Saisir la taille : ");
            int taille = int.Parse(Console.In.ReadLine());
            for(int i = 0; i < taille; i++){
                characterIndex = i % chars.Length;
                for(int j = 0; j < taille; j++){
                  Console.Write(chars[characterIndex]);
                  characterIndex++;
                  if(characterIndex == chars.Length)
                      characterIndex = 0;
                }
                Console.WriteLine("");
            } 
        }
