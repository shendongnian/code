    using System.Collections.ObjectModel;
    // ...
    public static ReadOnlyCollection<string> Titles { get; } = new ReadOnlyCollection<string>(
      new string[] { "German", "Spanish", "Corrects", "Wrongs" }
    );
