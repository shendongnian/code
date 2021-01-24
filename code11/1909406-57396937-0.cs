 lang-cs
class A {}
class B : A { }
class C : A { }
var list = new List<List<A>>();
var sublist_b = new List<B>();
sublist_b.Add(new B());
list.Add(sublist_b);
var sublist = list.Single();
sublist.Add(new C()); // <- now a List<B> contains an object that ist not if type B or derived B
I would suggest that you only use `ObservableItemCollection<ItemBase>` to hold your objects.
