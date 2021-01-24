    class Program
    {
      public class Couple
      {
        public string Text;
        public bool Indicator;
        public Couple(string text, bool indicator)
        {
          Text = text;
          Indicator = indicator;
        }
      }
      static void Main(string[] args)
      {
        var list = new List<Couple>();
        list.Add(new Couple("a", false));
        list.Add(new Couple("b", false));
        list.Add(new Couple("c", true));
        list.Add(new Couple("d", false));
        list.Add(new Couple("e", false));
        list.Add(new Couple("f", true));
        list.Add(new Couple("g", true));
        list.Add(new Couple("h", true));
        list.Add(new Couple("i", false));
        list.Add(new Couple("j", true));
        list.Add(new Couple("k", true));
        list.Add(new Couple("l", false));
        list.Add(new Couple("m", false));
        var result = new List<List<Couple>>();
        int index = 0;
        bool last = list[0].Indicator;
        result.Add(new List<Couple>());
        foreach ( var item in list )
        {
          if ( item.Indicator != last )
          {
            index++;
            result.Add(new List<Couple>());
          }
          last = item.Indicator;
          result[index].Add(item);
        }
        for ( index = 0; index < result.Count; index++ )
        {
          Console.WriteLine($"List n°{index}");
          foreach ( var item in result[index] )
            Console.WriteLine($"  text: {item.Text}");
        }
        Console.WriteLine("");
        Console.ReadKey();
      }
