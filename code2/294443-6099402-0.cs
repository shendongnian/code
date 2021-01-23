    public interface IUnknown { }
    
    public class SoAndSo : IUnknown { }
    
    public class CustomCollection<IUnknown>
    {
    }
    
    public class Ancestor<T> where T : IUnknown
    {
        public virtual CustomCollection<T> GetEntities()
        {
            return null;
        }
    }
    
    public class Descender : Ancestor<SoAndSo>
    {
        public override CustomCollection<SoAndSo> GetEntities()
        {
            return base.GetEntities();
        }
    }
