    class Class1
    {
        public class ItemData
        {
            public string Address;
            public dynamic Value;
        }
        public class SheetData
        {
            public List<ItemData> Items = new List<ItemData>();
            Items.Add(new ItemData());
            Items.Add(new ItemData());
            Items.Add(new ItemData());
        }
        public Class1
        {
            SheetData sheetData = new SheetData();
            //More stuff done
        }
    } 
Then you can use a foreach loop to access each ItemData inside the list
foreach (var item in sheetData.Items)
