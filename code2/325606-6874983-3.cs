    public partial class Form1 : Form, IPersonView {
       private PersonPresenter Presenter { get; set; }
          
       public Form1() {
          Presenter = new PersonPresenter(this, new PersonDb());
    
          InitializeComponent();
    
          InvokeInitialize(new EventArgs());
       }
    
       public string PersonName {
          get { return tbName.Text; }
          set { tbName.Text = value; }
       }
    
       public DateTime? DOB {
          get {
             return String.IsNullOrWhiteSpace(tbDOB.Text) ?
                      (DateTime?) null :
                      DateTime.Parse(tbDOB.Text);
          }
          set {
             tbDOB.Text = String.Format("{0}", value);
          }
       }
    
       public event EventHandler Initialize;
    
       public void InvokeInitialize(EventArgs e) {
          EventHandler handler = Initialize;
          if (handler != null) {
             handler(this, e);
          }
       }
    
       public event EventHandler SavePerson;
    
       public void InvokeSavePerson(EventArgs e) {
          EventHandler handler = SavePerson;
          if (handler != null) {
             handler(this, e);
          }
       }
    }
