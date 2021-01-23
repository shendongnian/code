    // Compile using: csc ItemAtPoint.cs /r:UIAutomationClient.dll /r:WindowsBase.dll
    using System;
    using System.Windows.Automation;
    using System.Windows.Forms;
    class ItemAtPoint
    {
        public static void Main()
        {
            Console.WriteLine("Place pointer over item and hit return...");
            Console.ReadLine();
            // Get the AutomationElement that represents the window handle...
            System.Windows.Point point = new System.Windows.Point(Cursor.Position.X, Cursor.Position.Y);
            AutomationElement el = AutomationElement.FromPoint(point);
            // Print out the type of the item and its name
            Console.WriteLine("item is a \"{0}\" with name \"{1}\"", el.Current.LocalizedControlType, el.Current.Name);
        }
    }
