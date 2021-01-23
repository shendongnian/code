    static class XFactory
    {
      private int _id;
       public XFactory(int formId) {
          _id = formId;
       }
	   /// <summary>
	   /// Decides which class to instantiate.
   	   /// </summary>
	   public static Form Get()
	   {
	     switch (_id)
	     {
		case 0:
		    return new FormA();
		case 1:
		case 2:
		    return new FormB();
		case 3:
		default:
		    return new FromC();
	     }
	   }
    }
    public static void Main()
    {
    
      ShowThisForm(new XFactory(2));
    
    }
    
    public static void ShowThisForm(XFactory formFactory)
        {
            var xfrm = formFactory.Get();
            xfrm.Show();
        }
