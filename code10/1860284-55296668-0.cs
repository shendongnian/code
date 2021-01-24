    public class C
    {
        public IA NumericalIA { get; set; }
        public IA FormulaIA { get; set; }
        public double DoCalculation()
        {
            if (this.FormulaIA != null && ShouldUseFormula()) // ShouldUseFormula is your logic for deciding
            {
                return this.FormulaIA.PerformCalculation();
            }
            else
            {
                return this.NumericalIA.PerformCalculation();
            }
        }
    }
