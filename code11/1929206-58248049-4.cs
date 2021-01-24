    static void Test()
    {
      Faction zerg = new Zerg("Zerg", new Army());
      zerg.Army.Recruit(new Zealot("Zealot"));
      Console.ReadKey();
    }
    public interface IUnit
    {
      string UnitName { get; set; }
      IFaction Nation { get; set; }
      void PrintUnitInfo();
    }
    abstract public class Unit : IUnit
    {
      public string UnitName { get; set; }
      public IFaction Nation { get; set; }
      public Unit(string name)
      {
        UnitName = name;
      }
      public virtual void PrintUnitInfo()
      {
        Console.WriteLine($"UnitName: {UnitName}\nNation: {Nation}\n");
      }
    }
    public interface IFaction
    {
      Army Army { get; set; }
      string Name { get; }
      int Minerals { get; set; }
      void Greetings();
      void PrintUnitsInfo();
    }
    public abstract class Faction : IFaction
    {
      public string Name { get; }
      public int Minerals { get; set; }
      public Army Army { get; set; }
      public Faction(string name, Army army)
      {
        Name = name;
        Minerals = 100;
        Army = army;
      }
      public virtual void Greetings()
      {
        Console.WriteLine("Printing FucntionInfo from BaseFaction");
      }
      public virtual void PrintUnitsInfo()
      {
        Console.WriteLine("Printing UnitsInfo from BaseFaction");
      }
    }
    public class Army
    {
      private List<IUnit> units = new List<IUnit>();
      public void Recruit(IUnit unit)
      {
        units.Add(unit);
      }
      public void PrintFactionName()
      {
        Console.WriteLine(nameof(IFaction));
      }
    }
    public class Zerg : Faction
    {
      public Zerg(string name, Army army) : base(name, army) { }
    }
    public class Zealot : Unit
    {
      public Zealot(string name) : base(name) { }
    }
