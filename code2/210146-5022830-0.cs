    private double totalFee;
    
                        //A:
    public AddJobs(double TotalFee)
    { //A:
        totalFee = TotalFee;
    }
    public static void Main()
    {
        Job job1 = new Job("washing windows", 5.00, 25.00);
        Job job2 = new Job("walking a dog", 3.00, 11.00);
        Job job3;
        job3 = job1 + job2;
        Console.WriteLine("The first job's description: {0} \nTotal time needed to complete the job: {1} hours \nHourly fee: {2} per hour", job1.Description, job1.Time, job1.Rate.ToString("C"));
        TotalPay(job1);
        Console.WriteLine("The second job's description: {0} \nTotal time needed to complete the job: {1} hours \nHourly fee: {2} per hour", job2.Description, job2.Time, job2.Rate.ToString("C"));
        TotalPay(job2);
        Console.WriteLine("The third job's description: {0} \nTotal time needed to complete the job: {1} hours \nHourly fee: {2} per hour", job3.Description, job3.Time, job3.Rate.ToString("C"));
        TotalPay(job3);
    }
    public static void TotalPay(Job method)
    {
 
        double totalFee = method.Rate * method.Time;
        Console.WriteLine("The total fee is: {0}", totalFee.ToString("C"));
    }
