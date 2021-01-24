public class Video
{
    public string URL { get; set; }
    public int Order { get; set; }
}
public class Image
{
    public string Name { get; set; }
    public int Order { get; set; }
}
public class Product
{
    public List<Video> videoList { get; set; }
    public List<Image> imageList { get; set; }
    public List<IOrdered> OrderedStuff => 
        videoList
        .Select(x => new VideoInterfaced(x) as IOrdered)
        .Union(imageList.Select(x => new ImageInterfaced(x) as IOrdered))
        .OrderBy(x => x.Order)
        .ToList();
}
public interface IOrdered
{
    int Order { get; set; }
}
public class VideoInterfaced : Video, IOrdered
{
    public VideoInterfaced(Video origin) : base(origin)
    {
        //...
    }
}
public class ImageInterfaced : Image, IOrdered
{
    public ImageInterfaced(Image origin) : base(origin)
    {
        //...
    }
}
