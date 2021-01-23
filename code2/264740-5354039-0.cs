    private static void Main(string[] args) {
        bool inputComplete = false;
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        while (!inputComplete ) {
        
            System.ConsoleKeyInfo key = System.Console.ReadKey(true);
            if (key.Key == System.ConsoleKey.Enter ) {                
                inputComplete = true;
            }
            else if (char.IsDigit(key.KeyChar)) {
                sb.Append(key.KeyChar);
                System.Console.Write(key.KeyChar.ToString());
            }
        }
        System.Console.WriteLine();
        System.Console.WriteLine(sb.ToString() + " was entered");
    }
