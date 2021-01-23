static void Test&lt;T&gt;(T it) where T:IValue
{
  T duplicate = it;
  it.value += 1;
  duplicate.value += 10;
  Console.WriteLine(it.value.ToString());
}
static void Test()
{
  ValueStruct v1 = new ValueStruct();
  v1.value = 9;
  IValue v2 = v1;
  Test&lt;ValueStruct&gt;(v1); 
  Test&lt;ValueStruct&gt;(v1); 
  Test&lt;IValue&gt;(v1); 
  Test&lt;IValue&gt;(v1); 
  Test&lt;IValue&gt;(v2);
  Test&lt;IValue&gt;(v2);
}
