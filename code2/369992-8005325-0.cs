    class Student
    {
        public int Id { get;set;}
    }
    class StudentPropertyDefintion
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string PropertyName { get; set; }
    }
    class StudentPropertyValue
    {
        public int PropertyDefinitionId { get; set; }
        public string PropertyValue { get; set; }
    }
    class Context
    {
        public ISet<Student> Students { get; set; }
        public ISet<StudentPropertyDefintion> PropertyDefinitions { get; set; }
        public ISet<StudentPropertyValue> PropertyValues { get; set; }
    }
    // and query that
      Context context = new Context();
            var studentWithPropertiesQuery = from student in context.Students
                                             join propertyDefinition in context.PropertyDefinitions
                                             on student.Id equals propertyDefinition.StudentId
                                             join propertyValue in context.PropertyValues
                                             on propertyDefinition.Id equals propertyValue.PropertyDefinitionId
                                             select new
                                             {
                                                 propertyValue,
                                                 propertyDefinition,
                                                 student
                                             };
