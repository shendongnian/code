    public static int Roll() {
       return Roll(new Random(), 1);
    }
    public static int Roll(Random random, int diceCount) {
        int sum = 0;
        for (int dice = 1; dice <= diceCount; ++dice) {
            int rolled = random.Next(1, 7);
            if (rolled == 6) {
                sum += Roll(random, 2)
            }
            else
            {
                sum += rolled;
            }
        }
        return sum;
    }
