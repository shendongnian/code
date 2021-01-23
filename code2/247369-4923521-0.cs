using System.DirectoryServices
    // Assuming your Server Id is 1, and you are connecting to your local IIS.
    DirectoryEntry de = new DirectoryEntry(@"IIS://localhost/W3SVC/1/Root");
    foreach (DirectoryEntry entry in de.Children)
    {
       foreach (PropertyValueCollection property in entry.Properties)
       {
          Console.WriteLine("Name: {0}, Value {1}",property.PropertyName, property.Value);
       }
    }
