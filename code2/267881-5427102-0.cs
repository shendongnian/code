    public class FOO : IHasStatus
    {
        public static A
        { 
           get / set A;
        }   
        public static B
        {
           get / set B;
        }   
        public static C
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
