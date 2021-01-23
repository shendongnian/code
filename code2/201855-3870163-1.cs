    using System.Linq;
    var y = new SortedList<string, string>();
    y.Add("Element1Key", "Element1Value");
    y.Add("Element2Key", "Element2Value");
    ...
    y.Add("Element20000Key", "Element20000Value"); // ;)
    var MyFirstFive = y.Take(5);
