    public class Entity
    { 
       public string Field { get; set; }
    }
    public class Dto
    { 
        public string Field { get; set; }
    }
    
    var dtos = context.Entities
        .Where(x => x.IsActive)
        .Select(x => new Dto
        {
            Field = x.Field
        })
        .ToList();
