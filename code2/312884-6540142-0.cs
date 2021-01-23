    for(int i = 1; i < bound; i += 2) {
        for(int j = 2; j <= 4; j += 2) {
            Console.WriteLine(
                String.Format("/html/body/table/tr[{0}]/td[{1}]", i, j)
            );
        }
        Console.WriteLine();
    }
