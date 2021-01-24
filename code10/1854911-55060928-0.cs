    using System.ComponentModel.DataAnnotations.Schema;
    public class MyClass
    {
     public string PropertyOne { get; set; }
     [NotMapped]
     public MyClass Country { get; set; }
    }
