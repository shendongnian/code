    public interface IGpasData<T>
    {
        List<T> ConvertToList(StreamReader reader);
    }
    public class GpasTableOfContent : IGpasData<GpasTableOfContent>
    {
        //...
        public List<GpasTableOfContent> ConvertToList(StreamReader reader)
        {
            //...
        }
    }
