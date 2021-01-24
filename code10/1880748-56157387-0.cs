    private static List<Animal> GetAnimalsToButcher()
    {
        List<ButcheringMemo> butcheringMemos = getAllButcheringMemos();
        return getAllAnimals()
            .Where(animal => butcheringMemos.Any(memo =>
                memo.AnimalName.Equals(animal.Name, StringComparison.OrdinalIgnoreCase)))
            .ToList();
    }
