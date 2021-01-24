interface InpcTrait : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    private T Set(T value,String propertyName = "")
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        return value;
    }
}
class Customer
{
    private string _name;
    public string Name 
    {
        get=>_name;
        set=>_name=Set(value,"Name");
    }
}
Unfortunately, this isn't possible. That's because the `event` keyword in a class generates a **backing field** that holds the *event handler* and add/remove accessors. When we raise the event, we call that event handler.
Interfaces can't have state, which means we can't access that event to raise it. 
When we specify an event in an interface, we create a virtual event and the compiler only allows adding/removing event handlers to it. Raising the interface still requires access to the backing field. 
[This Sharplab.io example](https://sharplab.io/#v2:EYLgtghgzgLgpgJwD4AEBMBGAsAKBQBgAIUMA6AYQHswAHSgOznpgFlKATOAGwG5cUAzMTSEAInDCVyAV1jVEhEIQCSAOUowAlgDMAngAUElGohi7yACwj0A5nHa4A3rkKvCAeneEAKhbhQ4Qm1NbnYoQgtKLnZCGD9CADcILml/IMoEWPjBQhojEwQtf1IXNzzNJPhCAHFpTRj6gDVk1MIAXhq69lJVOAB3WvqACgBKPhw3XIQKiCqSIgBjWRh5BFUIMDhmlMCOgGUYadtSAFFaM3HJ8srA+dzIxlVpMGBEbdb9w81js5oL3FKrhycASTBghEMxlM5istnsJ1BzAAEtZ2FwFJCCmZLNY7OxxoCpjM5gAWQjqLR6THQnFw9hDA5HGxTKGFXTrTbtQgAIm5I0JzgmkzcOkIQ2pbNpeMIAEIOvRpFwuPyhcLCIK1WqJdjYXihnFNFAADSERh9CH5Gm6+GImAAQQQNigQzyrLMHLgIzGhMmAF9Cf6cIGgA=) shows that :
public class DemoCustomer : INotifyPropertyChanged
{
    // These fields hold the values for the public properties.
    private Guid idValue = Guid.NewGuid();
    private string customerNameValue = String.Empty;
    private string phoneNumberValue = String.Empty;
    public event PropertyChangedEventHandler PropertyChanged;
    private void NotifyPropertyChanged(String propertyName = "")
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
Generates 
    [CompilerGenerated]
    private PropertyChangedEventHandler m_PropertyChanged;
    public event PropertyChangedEventHandler PropertyChanged
    {
        [CompilerGenerated]
        add
        {
            //some code
        }
        [CompilerGenerated]
        remove
        {
            //some code
        }
    }
    private void NotifyPropertyChanged(string propertyName = "")
    {
        if (this.m_PropertyChanged != null)
        {
            this.m_PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
What we can do, is add or remove event handlers, but we can't even check whether the event already has other handlers. We risk adding the same event handler multiple times. 
This is valid :
interface INPCtrait:System.ComponentModel.INotifyPropertyChanged
{            
    private  void AddSomeDefaultHandler()
    {
       PropertyChanged+=Something;
    }
    private  void RemoveDefaultHandler()
    {
       PropertyChanged-=Something;
    }
    
    public void Something(Object sender,System.ComponentModel.PropertyChangedEventArgs args)
    {
    }    
}
But we have no way of knowing whether we need to add that default handler or not. 
