    namespace x.Controls.Conference - add the class that derives from UserControl
    { 
        public partial class SlideShow : System.Web.UI.UserControl{...}
    }
    namespace x.Controls.Conference.SlideShowUC - add here the base class of the collection item in the UC (Collection<Slide>)
    {
     public class Slide{...}
     public class SlideCollectionEditor : CollectionEditor{...}
    }
