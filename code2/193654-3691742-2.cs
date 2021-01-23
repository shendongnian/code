    interface ILikeBananas
    {
        double GreenBananaPreferenceFactor { get; set; }
    }
    class Factory<T> where T : ILikeBananas, new()
    {
        public T Create(double greenBananaPreferenceFactor)
        {
            ILikeBananas result = new T();
            result.GreenBananaPreferenceFactor = greenBananaPreferenceFactor;
            return result;
        }
    }
