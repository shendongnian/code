    static string ConvertToBase9(int value) {
        char[] base9 = "123456789".ToCharArray();
        int num = 9;
        string result = string.Empty;
        do {
            result = base9[value % num] + result;
            value = value / num;
        } while (value > 0);
        return result;
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
