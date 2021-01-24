    public class Randomizer{
        private static Random rng = new Random();
        public static string RandomizeString(string input){
            StringBuilder sb = new StringBuilder();
            foreach(char c in input){
                if(Char.IsNumber(c)){
                    sb.Append(rng.Next(0,10));
                }
                else if(Char.IsLower(c)){
                    sb.Append((char)rng.Next(97,123));
                }
                else if(Char.IsUpper(c)){
                    sb.Append((char)rng.Next(65,91));
                }
                else{
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
