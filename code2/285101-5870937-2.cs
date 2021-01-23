    public class ImageFactory
    {
        Dictionary<Type, Func<IPerson, Image>> _creators;
        void Assign<TPerson>(Func<IPerson, Image> imageCreator) where T : IPerson
        {
           _creators.Add(typeof(TPerson), imageCreator);
        }
       void Create(Person person)
       {
           Func<IPerson, Image> creator;
           if (!_creators.TryGetValue(person.GetType(), out creator))
              return null;
           return creator(person);
       }
    }
