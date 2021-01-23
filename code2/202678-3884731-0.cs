    using System;
    using WatiN.Core;
    namespaceWatiNGettingStarted
    {
      class WatiNConsoleExample
      {
        [STAThread]
        static void Main(string[] args)
        {
          // Open a new Internet Explorer window and
          // goto the google website.
          IE ie = new IE("http://www.google.com");
          // Find the search text field and type Watin in it.
          ie.TextField(Find.ByName("q")).TypeText("WatiN");
          // Click the Google search button.
          ie.Button(Find.ByValue("Google Search")).Click();
 	
          // Uncomment the following line if you want to close
          // Internet Explorer and the console window immediately.
          //ie.Close();
        }
      }
}    
