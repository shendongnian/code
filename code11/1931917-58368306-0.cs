public class IntContainer {
   private Int _intValue;
   private IEnumerable<Int> _intCollection;
   public IntContainer(Int val) {
      this._intValue = val;
   }
   public IntContainer(IEnumerable<Int> val) {
      this._intCollection = val;
   }
   public bool IsSingleValue() => _intCollection == null;
   public bool IsMultiValue() => _intCollection != null;
}
Then have a `List<IntContainer>` like so:
var myList = new List<IntContainer>{
new IntContainer(new [] { 1, 2})
};
myList.Add(new IntContainer(3));
myList.Add(new IntContainer(new [] { 4,5,6 })); // etc..
Note: the real difference is not between PHP and C#, but between statically typed and dynamically typed languages.
