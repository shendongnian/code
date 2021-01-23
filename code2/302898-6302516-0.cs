    public class Fruit
    {
        int ID { get; set; }
        bool IsTasty { get; set; }
        string MyOtherPropert { get; set; }
        DateTime Date { get; set; }
    }
    ...
    if (id == -1)
    {
        //The object was unknown so create it
        var newUnknown = new Fruit
        {
            Name = "UNKNOWN"
        };
        EntityFramework.AddToFruits (newUnknown);
        EntityFramework.SaveChanges ();
        defaultValueObject = EntityFramework.Fruits.Single (x=>x.FruitID == newUnknown.FruitID);
        defaultValueObject.Date = DateTime.Now;
        UpdateModel (object, new string[] { "IsTasty", "MyOtherProperty" });
        EntityFramework.SaveChanges ();
    }
