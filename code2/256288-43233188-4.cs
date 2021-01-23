    using System.Collections.ObjectModel;
    // ...
    public ReadOnlyCollection<string> Titles { get; } = new ReadOnlyCollection<string>(
      new string[] { "German", "Spanish", "Corrects", "Wrongs" }
    );
