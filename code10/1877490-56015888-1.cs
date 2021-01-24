        public string Field { get; private set; }
    
        public Dto(Entity entity)
        {
           Field = entity.Field;
        }
    }
    
    var dtos = context.Entities
        .Where(x => x.IsActive)
        .Select(x => new Dto(x))
        .ToList();
