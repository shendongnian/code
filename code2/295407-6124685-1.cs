    var query = session.CreateCriteria<Base>()
                 .CreateAlias("Base.Reference1","ref1")
                 .CreateAlias("Base.Reference2","ref2")
                 .SetProjection(
                   Projections.ProjectionList()
                   .Add(Projections.Property("Base.BaseProperty"),"DtoBaseProperty")
                   .Add(Projections.Property("ref1.property1"),"DtoProperty1")
                   .Add(Projections.Property("ref2.property2"),"DtoProperty2")
                 )
                 .SetResultTransFormer(Transformers.AliasToBean(typeof(ProjectionDto)))
                 .List<ProjectionDto>();
    public class ProjectionDto{
        public string DtoBaseProperty;
        public string DtoProperty1;
        public string DtoProperty2;
    }
