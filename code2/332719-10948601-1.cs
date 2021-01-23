     [ParseChildren(true)]
      public partial class Popup : System.Web.UI.UserControl
      {
       [TemplateContainer(typeof(MessageContainer))]
       [PersistenceMode(PersistenceMode.InnerProperty)]
       public ITemplate MessageTemplate { get; set; } 
       public string Text { get; set; }
      protected void Page_Init(object sender, EventArgs e)
      {
        ltTitre.Text = Text;
         if (MessageTemplate != null)
         {
            var i = new MessageContainer();
            MessageTemplate.InstantiateIn(i);
            PlaceHolder1.Controls.Add(i);
         }           
       }
         public class MessageContainer : Control, INamingContainer{ }
     }
