    public async Task<Dictionary<char, int>> GetCustomersByInitialsCount()
    {
        return await Task.Run(async delegate
        {
            var dictionary = new Dictionary<char, int>();
            var letters = GetCustomerFirstLetter();
            foreach(letter in letters)
            {
                var count = await CustomerRepository.GetCustomerCountStartingWith(letter);
                dictionary.Add(letter, count);
            }
            return dictionary;
        });
    }
