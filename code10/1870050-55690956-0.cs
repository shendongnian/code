    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication108
    {
        class Program
        {
            const string FILENAME = "groceries.txt";
            static void Main(string[] args)
            {
                GroceryItem grocery = new GroceryItem();
                grocery.ReadFile(FILENAME);
            }
        }
        class GroceryItem
        {
            public static List<GroceryItem> items = new List<GroceryItem>();
            public string _type { get; set; }
            public string name { get; set; }
            public decimal price { get; set; }
            public int quantity { get; set; }
            public decimal weight { get; set; }
            public void ReadFile(string filename)
            {
                string line = "";
                StreamReader reader = new StreamReader(filename);
                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Trim();
                    if(line.Length > 0)
                    {
                        string[] splitArray = line.Split(new char[] { ',' });
                        //regular item cost calculator
                        _type = splitArray[0];
                        name = splitArray[1];
                        PurchasedItem purchasedItem = new PurchasedItem(splitArray); //testing to return value to print into the write out file
                        items.Add(purchasedItem);
                    }
                }
            }
            public class PurchasedItem : GroceryItem //inheriting properties from class GroceryItem
            {
                public PurchasedItem(string[] splitArray)
                {
                    this._type = splitArray[0];
                    this.name = splitArray[1];
                    this.quantity = int.Parse(splitArray[2]);
                    this.price = decimal.Parse(splitArray[3]);
                }
                public decimal regularCost() //method from cost of regular
                {
                    return this.price * this.quantity * (decimal)1.1; //workout out cost  for purchases including GST
                }
               
            }
     
        }
    }
