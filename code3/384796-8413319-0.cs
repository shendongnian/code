    public class BookASessionScreen
    {
    	private RootElement _root = null;
    	
    	private EntryElement _firstName = null;
    	
    	private EntryElement _lastName = null;
    	
    	private EntryElement _email = null;
    	
    	private DateElement _date = null;
    	
    	private RootElement _typeOfShoot = null;
    	
    	private EntryElement _message = null;
    	
    	private void CreateRoot()
    	{
    		_firstName = new EntryElement("First Name", "First Name", "");
    		_lastName = _firstName = new EntryElement("First Name", "First Name", "");
    		_email = new EntryElement("Email", "Email", "") { KeyboardType = UIKeyboardType.EmailAddress };
    		_date = new DateElement("Event Date", DateTime.Now);
    		_typeOfShoot = new RootElement ("Type of Shoot", new RadioGroup (0)){
                new Section () {
                    new RadioElement("Wedding"),
                	new RadioElement("Portrait"),
                	new RadioElement("Boudoir"),
                	new RadioElement("Other")
                }
            };
    		_message = new EntryElement("Message", "Message", "");
    		
    		_root = new RootElement("Book a Session") {
    	        new Section() {
    	            _firstName,
    	            _lastName,
    	            _email,
    	            _date,
    	            _typeOfShoot,
    	            _message
    	        } ,
    	        new Section () {
    	            new StringElement("Message", delegate { 
    					//BookASession.SendMessage(_firstName.Value, _lastName.Value, ...)
    				})
    	        }
    	    };
    	}
    	
    	public RootElement Root 
    	{
    		get {
    			if (_root == null) {
    				CreateRoot();
    			}
    			return _root;
    		}
    	}
    }
