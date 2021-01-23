    public Teacher ConvertInterfaceToClass(ITeacher teacher)
    {
        return teacher.MapTo<Teacher>();
    }
    
    public void CopyTeacher(Teacher source, out Teacher destination)
    {
        destination = source.MapTo<Teacher>();
    }
