    [DelimitedRecord(","), IgnoreFirst(1)]
    public class Person
    {
        // Must specify FieldOrder too
        [FieldOrder(1), FieldTitle("Name")]
        string name;
    
        [FieldOrder(2), FieldTitle("Age")]
        int age;
    }
    
    ...
    
    var engine = new FileHelperEngine<Person>
    {
        HeaderText = typeof(Person).GetCsvHeader()
    };
    
    ...
    
    engine.WriteFile(@"C:\people.csv", people);
