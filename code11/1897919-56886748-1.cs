 c#
interface IHazName { string Name {get;} }
interface IHazTitle { string Title {get;} }
interface ICanSpeak { void Speak(); }
...
foreach (Animal item in animals)
{
  if (item is ICanSpeak cs) cs.Speak();
  if (item is IHazTitle ht) Write(ht.Title);
  if (item is IHazName hn) Write(hn.Name);
}
...
class Cat : Animal, IHazName, ICanSpeak
{...}
class Dog : Animal, IHazName, ICanSpeak
{...}
class Person : Animal, IHazName, IHazTitle, ICanSpeak
{...}
class Spider : Animal, IHazName
{...}
One particularly nice thing about using interfaces is that you can fudge the names a bit:
 c#
class Dog : Animal, IHazName, ICanSpeak
{
    //...
    public void Bark() { Say("woof"); } // method is called Bark on the public API
    void ICanSpeak.Speak() => Bark(); // but Speak on the ICanSpeak API
}
---
Note: the usage here:
 c#
  if (item is ICanSpeak cs) cs.Speak();
requires a modern C# compiler; if you're using an older compiler, then:
 c#
  if (item is ICanSpeak) ((ICanSpeak)item).Speak();
or:
 c#
  var cs = item as ICanSpeak;
  if (cs != null) cs.Speak();
Likewise,
 c#
void ICanSpeak.Speak() => Bark();
is the same as, on older compilers,
 c#
void ICanSpeak.Speak() { Bark(); }
