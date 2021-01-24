    public abstract class Data {
    }
    public class StringData : Data {
    }
    public class DecimalData : Data {
    }
    List<Data> dataCollection = new List<Data>();
    dataCollection.Add(new DecimalData());
    dataCollection.Add(new StringData());
    
