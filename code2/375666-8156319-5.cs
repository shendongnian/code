    public interface IDisplayItem
    {
    	event System.ComponentModel.ProgressChangedEventHandler ProgressChanged;
    	string Subject { get; }
    	string Description { get; }
    	// Provide everything you need for the display here
    }
