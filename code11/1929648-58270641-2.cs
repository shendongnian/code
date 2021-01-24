    public class NotificationBase
    {
    	// Simple 
        public NotificationBase(Page page, string title, string message)
        {
            (page.Master as SiteMaster).Notification(title, message);
        }
    
    	// With JS OnClick event. (OK button)
        public void NotificationBase(Page page, string title, string message, string buttonText, string onClientClick)
        {
            (page.Master as SiteMaster).Notification(title, message, buttonText, onClientClick);
        }
    	
    	// With JS OnClick event. (OK & Canncel buttons)
        public void NotificationBase(Page page, string title, string message, string okButtonText, string okButtonOnClientClick, string cancelButtonText, string cancelButtonOnClientClick)
        {
            (page.Master as SiteMaster).Notification(title, message, okButtonText, okButtonOnClientClick, cancelButtonText, cancelButtonOnClientClick);
        }
    }
    
    
    public static class Notification
    {
    	public static void Success(Page page) => new NotificationBase(page, "Success", "The transaction has been updated successfully.");
    	
    	public static void Failure(Page webpage, string strMassege) => new NotificationBase(webpage, "Failed", strMassege);
    	
        public static void AccessDenied(Page page) => new NotificationBase(page, "Access Denied", "You don't have permissions.", "Back", "redirect('/home');"); //redirect is just simple window.location in JS.
    }
