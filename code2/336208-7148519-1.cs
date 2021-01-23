    using System.Reflection;
    (...)
    public void VisitProperties(object subject)
    {
        Type subjectType = subject.GetType();
        foreach (PropertyInfo info in subjectType.GetProperties()
        {
             object value = info.GetValue(subject, null);
             Console.WriteLine("The name of the property is " + info.Name);
             Console.WriteLine("The value is " + value.ToString());
        }
    }
