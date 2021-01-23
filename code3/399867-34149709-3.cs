    using ExpressionFramework.Projections;
    using ExpressionFramework.Projections.Configuration;
    
    public class ProjectionModelBuilder : ProjectionModel
    {
        protected override void OnModelCreating(ProjectionModelBuilder modelBuilder)
        {
            ClientDTO.ProjectionModel(modelBuilder);
            OrderDTO.ProjectionModel(modelBuilder);
            AnotherDTO.ProjectionModel(modelBuilder);
        }
    }
