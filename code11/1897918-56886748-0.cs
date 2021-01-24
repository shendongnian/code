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
