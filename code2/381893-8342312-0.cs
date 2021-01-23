    using System;
    using System.Security;
    
    class Sample {
      static void Main() {
        string text = "Escape characters ： < > & \" \'";
        string xmlText = SecurityElement.Escape(text);
    //output:
    //Escape characters ： &lt; &gt; &amp; &quot; &apos;
        Console.WriteLine(xmlText);
      }
    }
