public partial class LINQtest2Entities
{
    [EdmFunction("LINQtest2Model.Store", "FNC_ADD")]
    public decimal FNC_ADD(decimal V1, decimal V2)
    {
        // don’t need to implement the function
        throw new ApplicationException();
    }
}
