public class Effect() 
{  
  public string Name() { get; set; }
}
public class SomeClass()
{
  private List&lt;Effect&gt; Effects;
  public static void WhateverMethod()
  {
    for (var i = 0; i &lt; Effects.Count; i++)
      Effects[i].Name = "Effect " + (i + 1).ToString();
  }
}
