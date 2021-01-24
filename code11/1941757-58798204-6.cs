    public interface IImplementationRepository : IEntityBaseRepository<Implementation> { }
    public class ImplementationRepository: BaseRepository<Implementation>
        , IImplementationRepository
    {
        public override Implementation GetSingle(int id)
        {
            
            return base.GetSingle(id);
        }
    }
