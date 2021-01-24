using System;
using System.Collections.Generic;
class MainClass 
{
  public static void Main (string[] args) 
  {
    List<String> items = new List<String>();
    string[] stuff = {"a1","b1","c1","d1", "foo1", "goo1"};
    items.AddRange(stuff);
    items.ForEach(i => Console.Write("{0}\t", i));
    List<String> letters = new List<String>();
    List<String> foo = new List<String>();
    List<String> goo = new List<String>();
    foreach(string a in items)
    {
      if(a.Contains("foo"))
      {
        foo.Add(a);
      }
      else if(a.Contains("goo"))
      {
        goo.Add(a);
      }
      else
      {
        letters.Add(a);
      }
    }
    letters.ForEach(i => Console.Write("{0}\t", i));
    foo.ForEach(i => Console.Write("{0}\t", i));
    goo.ForEach(i => Console.Write("{0}\t", i));
  }
}
