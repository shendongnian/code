public class MyServices : Service
{
    public object Post(CreateShortUrlRequest request) //Post an array/list of URLs to the database and get a respective list of short URL
    {
        using (Task4URLEntities db = new Task4URLEntities())
        {
            var urls = new List<string>();
            foreach (string LongUrl in request.LongUrl)
            {
                var item = new ShortURLs
                {
                    LongUrl = LongUrl,
                    ShortUrl = GetUrl(),
                    DateCreated = DateTime.Now
                };
                urls.Add($"http://localhost/{item.ShortUrl}");
                db.ShortURLs.Add(item);
            }
            var campaign = new Campaign
            {
                CampaignName = request.CampaignName,
                Enddate = request.Enddate,
                Startdate = request.Startdate
            };
            db.Campaign.Add(campaign);
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        Response.WriteAsync("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                    }
                }
            }
            return new CreateShortUrlResponse
            {
                Response = urls,
                CampaignId = campaign.CampaignId
            };
        }
    }
    public string GetUrl()
    {
        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var stringChars = new char[5];
        for (int i = 0; i < stringChars.Length; i++)
        {
            stringChars[i] = chars[_rng.Next(chars.Length)];
        }
        var finalString = new String(stringChars);
        return finalString;
    }
    private Random _rng = new Random();
 }
