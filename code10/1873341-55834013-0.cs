 C#
// assume that 'offer' is an Offer from the DB 
var latestStatus = offer.OfferStatuses.OrderByDescending(x => x.Timestamp).First();
You can add a "getter" on the model like so:
 C#
public class Offer
{
    // Getter method
    public OfferStatus GetLatestStatus
    {
        get { return OfferStatuses.OrderByDescending(x => x.Timestamp).FirstOrDefault(); }
        set { ; }
    }  
}
