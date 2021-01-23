    public static void Main()
       {
          int i = 100;
          
          // Creates a CultureInfo for English in Belize.
          CultureInfo bz = new CultureInfo("en-BZ");
          // Displays i formatted as currency for the bz.
          Console.WriteLine(i.ToString("c", bz));
          
          // Creates a CultureInfo for English in the U.S.
          CultureInfo us = new CultureInfo("en-US");
          // Display i formatted as currency for us.
          Console.WriteLine(i.ToString("c", us));
          
          // Creates a CultureInfo for Danish in Denmark.
          CultureInfo dk = new CultureInfo("da-DK");
          // Displays i formatted as currency for dk.
          Console.WriteLine(i.ToString("c", dk));
       }
