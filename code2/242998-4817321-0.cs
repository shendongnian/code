    public partial class MyUserControl:UserControl
    {
        public string ImageUrl
        {
            set{ image1.ImageUrl=value;}
            get{return image1.ImageUrl;}
        }
    }
    var ctrl=LoadControl("MyControl.ascx") as MyUserControl;
    if(ctrl!=null)
    {
        ctrl.ImageUrl = "image.mpg";
    }
