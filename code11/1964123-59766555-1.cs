void f() {
  if (MyFunc() is (true, var name1, var name2)) {
      Console.WriteLine(name1);
  }
}
Or widen the scope, by using a variable outside the block :
var (success,name1,name2)= MyFunc();
if (!success) return;
Console.WriteLine(name1);
Or use switch statements :
switch(MyFunc()) {
    case (false, _,):
        return ;
    case (success, var name1,var name2):
        Console.WriteLine(name1);        
        break;
}
You can also define individual variables and take advantage of the fact that assignments are expressions, but that gets ugly :
bool success;
string name1;
string name2; 
if ( ((success,name1,name2)=MyFunc()) is (false,_,_)) {
    return;
}
Console.WriteLine(name1);
