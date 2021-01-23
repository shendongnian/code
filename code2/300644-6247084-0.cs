    public interface IEntity
    {
        IEntity ConvertToUtcTime(Student);
        // more methods/properties
    }
    public void CreateTask<T>(T entity, Student student) where T : IEntity
    {
        T convertToUtcTime = entity.ConvertToUtcTime(student);
        session.Save(convertToUtcTime);
    }
