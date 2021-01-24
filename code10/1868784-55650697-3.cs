    [AutoMapFrom(typeof(Student))]
    public class StudentDto: EntityDto<long>
    {
         public string Name { get; set; }    
    }
    
