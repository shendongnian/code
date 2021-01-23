    public class FOO : IHasStatus
    {
        public A
        { 
           get / set A;
        }   
        public B
        {
           get / set B;
        }   
        public C
        {
           get / set C;
        }
    } 
    
    public void updateVarx(IHasStatus someObject, string varx)
    {
        someObject.A = varx;
    }
    public void updateVary(IHasStatus someObject, string vary)
    {
        someObject.B = vary;
    }
