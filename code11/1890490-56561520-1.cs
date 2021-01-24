    public class MyClass()
    {
    
        private IProdCalcService calcService;
    
        public MyClass(IProdCalcService calcService)
        {
            this.calcService = calcService;
        }
    
        public void IamMethodInBll()
        {
            //...
            prodSurr.CalculatedPrice = calcService.GetMyMethod();
            //...
        }
    }
