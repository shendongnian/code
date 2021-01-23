    [TestClass]
    public class when_i_add_two_numbers : with_calculator
    {
        public override void When()
        {
            this.calc.Add(2, 4);
        }
    
        [TestMethod]
        public void ThenItShouldDisplay6()
        {
            Assert.AreEqual(6, this.calc.Result);
        }
        [TestMethod]
        public void ThenTheCalculatorShouldNotBeNull()
        {
            Assert.IsNotNull(this.calc);
        }
    }
    
    public abstract class with_calculator : SpecificationContext
    {
        protected Calculator calc;
    
        public override void Given()
        {
            this.calc = new Calculator();
        }
    }
    
    public abstract class SpecificationContext
    {
        [TestInitialize]
        public void Init()
        {
            this.Given();
            this.When();
        }
    
        public virtual void Given(){}
        public virtual void When(){}
    }
    
    public class Calculator
    {
        public int Result { get; private set; }
        public void Add(int p, int p_2)
        {
            this.Result = p + p_2;
        }
    }
