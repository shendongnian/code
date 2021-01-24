    public static async Task<(long averageSalary, long numberOfEmployee)> SomeCalculation(long num1, long num2, bool b)
    {
        long averageSalary = num1;
        long numberOfEmployee = num2;
        return (averageSalary, numberOfEmployee);
    }
    static async Task Main(string[] args)
    {
        var (averageSalary, numberOfEmployee) = await SomeCalculation(0L, 10, 0L == 10L);
    }
