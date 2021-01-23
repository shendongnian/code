    public class BaseController : Controller {
        //  GET: /Addresses/{AddressId}/Delete
        public void DeleteAddress(
            int AddressId) {
            this.AddressProvider.DeleteAndSave(AddressId);
            Response.Redirect(Request.UrlReferrer.AbsoluteUri);
        }
        //  GET: /Emails/{EmailId}/Delete
        public void DeleteEmail(
            int EmaildId) {
            this.EmailProvider.DeleteAndSave(EmailId);
            Response.Redirect(Request.UrlReferrer.AbsoluteUri);
        }
        //  GET: /Phones/{PhoneId}/Delete
        public void DeletePhone(
            int PhoneId) {
            this.PhoneProvider.DeleteAndSave(PhoneId);
            Response.Redirect(Request.UrlReferrer.AbsoluteUri);
        }
    }
