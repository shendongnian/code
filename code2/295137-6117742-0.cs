    public class Card
    {
        public int a;
        public string b, c, d;
        
        public Card(int a, string b, string c, string d)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
        }
        
        public static Card Parse(string input)
        {
            int a;
            string b, c, d;
            // There are several string splitting methods shown in other answers, pick the one you like.
            return new Card(a, b, c, d);
        }
    }
