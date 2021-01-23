    static char[] base9 = "123456789".ToCharArray();
    static string ConvertToBase9(int value) {
        int num = 9;
        char[] result = new char[9];
        for (int i = 8; i >= 0; --i) { 
            result[i] = base9[value % num];
            value = value / num;
        }
        return new string(result);
    }
    public static void generateIdentifiers(int quantity) {
        var uniqueIdentifiers = new List<string>(quantity);
        // we have 387420489 (9^9) possible numbers of 9 digits in base 9.
        // if we choose a number that is prime to that we can easily get always
        // unique numbers
        Random random = new Random();
        int inc = 386000000;
        int seed = random.Next(0, 387420489);
        while (uniqueIdentifiers.Count < quantity) {
            uniqueIdentifiers.Add(ConvertToBase9(seed));
            seed += inc;
            seed %= 387420489;
        }
    }
