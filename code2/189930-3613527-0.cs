    /// <summary>
    /// Represents a button with its text and 
    /// the controller name it will redirect to
    /// </summary>
    public class Button
    {
        public string Text { get; set; }
        public string Controller { get; set; }
    }
    /// <summary>
    /// Represents the page with a header and a list of buttons
    /// </summary>
    public class Page
    {
        public string Header { get; set; }
        public IEnumerable<Button> Buttons { get; set; }
    }
    
    /// <summary>
    /// Each view model will have page metadata
    /// </summary>
    public abstract class BaseViewModel
    {
        public Page Page { get; set; }
    }
    public class Page1ViewModel : BaseViewModel
    {
        // Put any properties specific to this page
        // which will be used for the input fields
    }
    public class Page2ViewModel : BaseViewModel
    {
        // Put any properties specific to this page
        // which will be used for the input fields
    }
    ...
