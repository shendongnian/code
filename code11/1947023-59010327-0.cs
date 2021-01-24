csharp
Entity1Service _entity1Service = new Entity1Service();
dynamic MyDynamic = new System.Dynamic.ExpandoObject();
MyDynamic.Serial = "serial";
var e1 = _entity1Service.GetBySerial(MyDynamic.Serial);
... the compile-time type of `MyDynamic.Serial` is `dynamic`, and the call to `_entity1Service.GetBySerial` is dynamically bound, with a result of `dynamic`. When you explicitly type `e1` as `Entity1`, you're effectively adding a cast after the call.
If you just make sure everything in the expression is statically typed, the result will have the static type you expect. For example, you could cast the argument:
csharp
Entity1Service _entity1Service = new Entity1Service();
dynamic MyDynamic = new System.Dynamic.ExpandoObject();
MyDynamic.Serial = "serial";
var e1 = _entity1Service.GetBySerial((string) MyDynamic.Serial);
Or you could use a separate local variable:
csharp
Entity1Service _entity1Service = new Entity1Service();
dynamic MyDynamic = new System.Dynamic.ExpandoObject();
MyDynamic.Serial = "serial";
string serial = MyDynamic.Serial;
var e1 = _entity1Service.GetBySerial(serial);
Either way, the `_entity1Service.GetBySerial` call is now statically bound - which is almost certainly what you want - and the type of `e1` will be `Entity1`.
