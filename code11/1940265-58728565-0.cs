public class BTCRootObject
{
    public List<BTCDatum> data { get; set; }
    public BTCContext context { get; set; }
}
This way the `BTCDatum` is filled correctly.
