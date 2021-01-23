    using System;
    using System.Globalization;
    using System.Threading;
    public class EuroLocalSample
    {
       public static void Main()
       { 
         // Create a CultureInfo object for French in France.
         CultureInfo FrCulture = new CultureInfo("fr-FR");
         // Set the CurrentCulture to fr-FR.
         Thread.CurrentThread.CurrentCulture = FrCulture;
        // Clone the NumberFormatInfo object and create
        // a new object for the local currency of France.
        NumberFormatInfo LocalFormat =
        (NumberFormatInfo)NumberFormatInfo.CurrentInfo.Clone();
        // Replace the default currency symbol with the local
        // currency symbol.
        LocalFormat.CurrencySymbol = "F";
    
        int i = 100;
 
        // Display i formatted as the local currency.
        Console.WriteLine(i.ToString("c", LocalFormat));
        // Display i formatted as the default currency.
        Console.WriteLine(i.ToString("c", NumberFormatInfo.CurrentInfo));
       }
    }
