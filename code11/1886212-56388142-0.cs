    public double WeekendAverage(int[] saturday, int[] sunday)
    {
        double sum = 0;
        for (int i = 0; i < saturday.Length; i++)
        {
            sum += saturday[i];
        }
        for (int i = 0; i < sunday.Length; i++)
        {
            sum += sunday[i];
        }
        return sum / (saturday.Length + sunday.Length);
    }
