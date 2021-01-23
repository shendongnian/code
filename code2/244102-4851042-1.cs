    using Emgu.CV;
    using Emgu.CV.CvEnum;
    using Emgu.CV.Structure;
    using Emgu.CV.UI;
    using System.Drawing;
     
    ...
     
    using (Image<Bgr, Byte> img = new Image<Bgr, byte>(400, 200, new Bgr(255, 0, 0))) 
    {
       MCvFont f = new MCvFont(CvEnum.FONT.CV_FONT_HERSHEY_COMPLEX, 1.0, 1.0);
     
       img.Draw("Hello, Stack Overflow", ref f, new Point(10, 80), new Bgr(0, 255, 0)); 
     
       //Show the image using ImageViewer from Emgu.CV.UI
       ImageViewer viewer = new ImageViewer(img, "Stack Test");
       viewer.ShowDialog();
    }
