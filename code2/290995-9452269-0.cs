    using System.Windows.Forms;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    namespace Whatever
    {
      [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design",
           typeof(IDesigner))] 
      public class MyPicContainer : PictureBox
      {
      }
    }
