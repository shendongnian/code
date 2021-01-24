private int[] delayParametersIndexSetup = new int[] {1, 0, 0, 1, 1, 0, 0, 1 };
private Dictionary<int, int> delayParameters =   new Dictionary<int, int>()
        {
            { 0, 1 },
            { 1, 500 }
        };
(...)
foreach (var index in delayParametersIndexSetup)
   {
       // TODO handle case when value unknown
       var value = this.delayParameters[index];
   }
If the values are contiguous, a list or an array could be OK too. 
private int[] delayParametersIndexSetup = new int[] {1, 0, 0, 1, 1, 0, 0, 1 };
private int[] delayParameters = new int[]{1,500};
(...)
foreach (var index in delayParametersIndexSetup)
{
   var value = delayParameters[index];
}
