    public delegate ReturnType MasterPageButtonHandler(CustomEventArgs ObjPriargs);
    public event MasterPageButtonHandler MasterPagebuttonClick;
    .
    .
    .
    .
    Button.click+=new EventHandler(Button1_Click);
    .
    .
    .
    protected void Button1_Click(Object sender,EventArgs e)
    {
         if(MasterPagebuttonClick!=null)
         {
             CustomEventArgs ObjPriargs=new CustomEventArgs();
             ObjPriargs.Property1=SomeValu1;
             ObjPriargs.Property2=SomeValu2;
             MasterPagebuttonClick.Invoke(ObjPriargs);
         }
    }
    .
    .
    .
    public class CustomEventArgs
    {
          Public DataType Property1{get;set;}
          Public DataType Property2{get;set;}
          Public DataType Property3{get;set;}
    }
    .
    .
    .
    //    Now in your aspx Page
    MyMaster m=Page.Master as MyMaster;
    m.MasterPagebuttonClick+=new MasterPageButtonHandler(MasterPageHandler_Click);
    .
    .
    .
    protected void MasterPageHandler_Click(CustomEventArgs ObjPriargs)
    {
        //You code/////
    }
