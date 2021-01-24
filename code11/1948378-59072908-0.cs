    public class ProductData
    {
	    public Video Video {get;set;}
	    public Image Image {get;set;}
    }
    public IDictionary<int,ProductData> AggrigateData(List<Video> videos, List<Image> images)
    {
	    var orderedSet = images.OrderBy(image => image.Order);
	    return videos.ToDictonary(video => video.Order, video => new ProductData {Video = video, Image = orderedSet.FirstOrDefault(image => image.Order == video.Order))}
    }
