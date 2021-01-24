    {
        public double AnnualSalesAmount { get; set; }
        public override void IncreaseSalary(double rate)
        {
            if (this.AnnualSalesAmount > 100000)
            {
                this.Salary += (this.Salary * (rate + 5) / 100);
            }
            else
            {
                this.Salary += (this.Salary * rate / 100);
            }
        }
    }
