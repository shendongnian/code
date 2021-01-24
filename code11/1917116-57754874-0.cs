    public partial class frmMain : Form
    {
       private frmChild form1=new frmChild();
       
       private DoSomeActionOnfrmChild()
       {
          frmChild.SomeAction();
       }
    }
    public partial class frmChild : Form
    {
       public void SomeAction()
       {}
    } 
