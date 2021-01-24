csharp
class ItemWithSalt :  IItem
{
    public double Price { get; set; } = 100.0;
    public double Calories { get; set; }
    public double Fats { get; set; }
    public double Proteins { get; set; }
    public double Sugars { get; set; }
    public double Salt { get; set; } = 4.0;
    public string Name { get; set; }
}
but then it would make more sense to drop the setters and create Items like that : 
csharp
interface IItem
{
    double Price { get;  }
    string Name { get;  }
    double Calories { get;  }
    double Fats { get;  }
    double Proteins { get;  }
    double Sugars { get;  }
    double Salt { get;  }
}
class SaltyItem: IItem
{
    public double Price => 100.00
    public double Salt => 4.0
    public string Name => "Salty";
}
class FattyItem: IItem
{
    public double Price => 100.00
    public double Fats => 4.0
    public string Name => "Fatty";
}
