    public class ImageFactory
    {
        Dictionary<Type, Func<Image>> _creators;
        void Assign<TPerson>(Func<Image> imageCreator) where T : IPerson
        {
           _creators.Add(typeof(TPerson), imageCreator);
        }
       void Create(Person person)
       {
           Func<Image> creator;
           if (!_creators.TryGetValue(person.GetType(), out creator))
              return null;
           return creator();
       }
    }
