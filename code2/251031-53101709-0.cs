    var classObj = new Class1();
    classObj.Name=>"StackOverflow";
    var property= new Class1().GetType().GetProperty(nameof(classObj.Name));
    var displayNameAttributeValue = (property ?? throw new 
    InvalidOperationException()).GetCustomAttributes(typeof(DisplayNameAttribute)) as 
    DisplayNameAttribute;   
    Console.WriteLine("{0} = {1}",displayNameAttributeValue,classObj.Name);
