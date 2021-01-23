    public partial class MainForm : Form
    {
        Image img;
        private void button1_Click(object sender, EventArgs e)
        {
            LoadImageAsynchronously("http://media1.santabanta.com/full5/Indian%20%20Celebrities(F)/Jacqueline%20Fernandez/jacqueline-fernandez-18a.jpg");
        }
        private void LoadImageAsynchronously(string url)
        {
            /*
            This is a classic example of how make a synchronous code snippet work asynchronously.
            A class implements a method synchronously like the WebClient's DownloadData(…) function for example
                (1)	First wrap the method call in an Anonymous delegate.
                (2)	Use BeginInvoke(…) and send the wrapped anonymous delegate object as the last parameter along with a callback function name as the first parameter.
                (3)	In the callback method retrieve the ar's AsyncState as a Type (typecast) of the anonymous delegate. Along with this object comes EndInvoke(…) as free Gift
                (4)	Use EndInvoke(…) to retrieve the synchronous call’s return value in our case it will be the WebClient's DownloadData(…)’s return value.
            */
            try
            {
                Func<Image> load_image_Async = delegate()
                {
                    WebClient wc = new WebClient();
                    Bitmap bmpLocal = new Bitmap(new MemoryStream(wc.DownloadData(url)));
                    wc.Dispose();
                    return bmpLocal;
                };
                Action<IAsyncResult> load_Image_call_back = delegate(IAsyncResult ar)
                {
                    Func<Image> ss = (Func<Image>)ar.AsyncState;
                    Bitmap myBmp = (Bitmap)ss.EndInvoke(ar);
                    if (img != null) img.Dispose();
                    if (myBmp != null)
                        img = myBmp;
                    Invalidate();
                    //timer.Enabled = true;
                };
                //load_image_Async.BeginInvoke(callback_load_Image, load_image_Async);             
                load_image_Async.BeginInvoke(new AsyncCallback(load_Image_call_back), load_image_Async);             
            }
            catch (Exception ex)
            {
               
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (img != null)
            {
                Graphics grfx = e.Graphics;
                grfx.DrawImage(img,new Point(0,0));
            }
        }
