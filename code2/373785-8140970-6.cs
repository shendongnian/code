    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            var itemsSource = new ObservableCollection<TwitterItem>();
            var initialTweets = new[]
                                    {
                                        new TwitterItem
                                            {CreatedAt = DateTime.Now.AddMinutes(-3)},
                                        new TwitterItem
                                            {CreatedAt = DateTime.Now.AddMinutes(-2)},
                                        new TwitterItem
                                            {CreatedAt = DateTime.Now.AddMinutes(-1)}
                                    };
            itemsSource.Merge(initialTweets.OrderByDescending(ti => ti.CreatedAt));
            var newTweets = new List<TwitterItem>();
            newTweets.Add(new TwitterItem {CreatedAt = DateTime.Now.AddMinutes(-3.5)});
            newTweets.Add(new TwitterItem {CreatedAt = DateTime.Now.AddMinutes(-2.5)});
            newTweets.Add(new TwitterItem {CreatedAt = DateTime.Now.AddMinutes(-1.5)});
            newTweets.Add(new TwitterItem {CreatedAt = DateTime.Now.AddMinutes(-0.5)});
            itemsSource.Merge(newTweets.OrderByDescending(ti => ti.CreatedAt));
            foreach (var twitterItem in itemsSource)
            {
                Debug.WriteLine(twitterItem.CreatedAt.ToString());
            }
        }
    }
    public class TwitterItem
    {
        public DateTime CreatedAt;
    }
    public static class ObservableTwitterItemsExtensions
    {
        public static void Merge(
            this ObservableCollection<TwitterItem> target, IEnumerable<TwitterItem> source)
        {
            int i = 0; // insert index
            foreach (var newTwitterItem in source)
            {
                while (i < target.Count &&
                    target[i].CreatedAt >= newTwitterItem.CreatedAt)
                {
                    i++;
                }
                target.Insert(i, newTwitterItem);
            }
        }
    }
