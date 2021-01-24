class DataReader
{       
     private static DataReader instance = null;
     private DataReader()
     {
       //workbook goes here...
     }
     public static DataReader Instance
     {
         get
         {
             if (instance == null)                   
                  instance = new DataReader();               
               return instance;
          }
      }     
}
And then you can call the method like:
...
sheet = DataReader.Instance.GetWorksheetByName("Your_CSV_File");
Here you not need to use the `new` keyword every time
