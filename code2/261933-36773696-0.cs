    using System.Collections.Immutable;
    using Angara.Data;
    using Angara.Data.DelimitedFile;
    ...
    ReadSettings settings = new ReadSettings(Delimiter.Semicolon, false, true, null, null);
    Table table = Table.Load("data.csv", settings);
    ImmutableArray<double> a = table["double-column-name"].Rows.AsReal;
    for(int i = 0; i < a.Length; i++)
    {
        Console.WriteLine("{0}: {1}", i, a[i]);
    }
