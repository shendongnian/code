    public interface IService {
        List<MyDto> GetByIds(int[] ids);
    }
    public class MyDto {
        public int Id { get; set; }
    }
