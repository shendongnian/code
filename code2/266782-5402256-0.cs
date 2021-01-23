    class Program
    {
      static void Main(string[] args)
      {
        Console.WriteLine("Welcome, please provide the following info... Confirm with <RETURN>!");
        Console.WriteLine();
    
        Console.Write("Name (e.g. 'Peggy Sue'): ");
        var user = GetUserInput<User>(Console.ReadLine());
    
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Hi {0}, nice to meet you!", user.Forename);
        Console.WriteLine();
        
        Console.Write("Age: ");
        user.Age = GetUserInput<ushort>(Console.ReadLine());
    
        Console.WriteLine();
        Console.WriteLine("Thanks and goodbye!");
        Console.WriteLine("Press <RETURN> to quit...");
        Console.ReadLine();
      }
    
      static T GetUserInput<T>(string data)
      {
        TypeConverter conv = TypeDescriptor.GetConverter(typeof(T));
        return (T) conv.ConvertFromInvariantString(data);
      }
    }
    
    [TypeConverter(typeof(UserConverter))]
    class User
    {
      public User(string name)
      {
        var splitted = name.Split(' ');
        Forename = splitted[0];
        Lastname = splitted[1];
      }
    
      public static explicit operator User (string value)
      {
        return new User(value);
      }
    
      public static explicit operator string (User value)
      {
        return string.Concat(value.Forename, " ", value.Lastname);
      }
    
      public string Forename { get; private set; }
      public string Lastname { get; private set; }
    
      public ushort Age { get; set; }
    }
    
    class UserConverter : TypeConverter
    {
      public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
      {
        return (typeof(string) == sourceType);
      }
    
      public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
      {
        if (value is string)
        {
          return (User)(value as string);
        }
    
        return null;
      }
    }
