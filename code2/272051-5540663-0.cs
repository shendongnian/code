    public interface SavableObject 
    {
        void Save(ObjectSaver saver);
        ObjectLoader ObjectLoader {get; set;}
    }
