    {
        public string Name { get; set; }
        public double Salary { get; set; }
        public void IncreaseSalary(double rate)
        {
            this.Salary += (this.Salary * rate / 100);
        }
    }
