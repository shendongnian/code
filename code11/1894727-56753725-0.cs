    private static void ASupplier(IReadOnlyCollection<IA> aCollection)
    {
        foreach (var a in aCollection)
        {
            Console.WriteLine(a.GetText());
        }
    }
