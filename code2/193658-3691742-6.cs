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
            return (T)result;
            //     ^^^^^^^^^
            //     freely converting between ILikeBananas and T is permitted
            //     only because of the interface constraint.
        }
    }
