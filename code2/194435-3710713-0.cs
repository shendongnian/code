    string cmpValue = "IMA".PadRight(10);
    
    var catIds = DetachedCriteria.For<Category>()
            .Add<Category>(c => c.TypeCode == cmpValue)
            .SetProjection(LambdaProjection.Property<Category>(s => s.Id));
