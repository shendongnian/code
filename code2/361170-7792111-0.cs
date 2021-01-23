    enum MatchType
    {
      NoMatch,
      ExactMatch,
      ClosestMatch
    };
    static MatchType FindColour (Color colour, out string name)
    {
      MatchType
        result = MatchType.NoMatch;
      int
        least_difference = 0;
      name = "";
      foreach (PropertyInfo system_colour in typeof (Color).GetProperties (BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy))
      {
        Color
          system_colour_value = (Color) system_colour.GetValue (null, null);
        if (system_colour_value == colour)
        {
          name = system_colour.Name;
          result = MatchType.ExactMatch;
          break;
        }
        int
          a = colour.A - system_colour_value.A,
          r = colour.R - system_colour_value.R,
          g = colour.G - system_colour_value.G,
          b = colour.B - system_colour_value.B,
          difference = a * a + r * r + g * g + b * b;
        if (result == MatchType.NoMatch || difference < least_difference)
        {
          result = MatchType.ClosestMatch;
          name = system_colour.Name;
          least_difference = difference;
        }
      }
      return result;
    }
    static void Main (string [] args)
    {
      string
        colour;
      MatchType
        match_type = FindColour (Color.FromArgb (0x2088C1), out colour);
      Console.WriteLine (colour + " is the " + match_type.ToString ());
      match_type = FindColour (Color.AliceBlue, out colour);
      Console.WriteLine (colour + " is the " + match_type.ToString ());
    }
