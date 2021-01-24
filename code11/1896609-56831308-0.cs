c#
public Action<int> btnClick(){ return 1;}
to
c#
public Action<object, EventArgs> btnClick(objet sender, EventArgs e){ /* code... */}
// Or alternatively
public void btnClick(object sender, EventArgs e) { /* code */}
and also change the Property in the Model
from
c#
[Parameter]
protected Action<int> ExternalMethod { get; set; }
to
c#
[Parameter]
protected Action<object, EventArgs> ExternalMethod { get; set; }
P.S the `Action<T>` class defines a method with the return type `void` and the Parameter T
