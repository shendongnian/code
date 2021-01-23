    using System;
    using System.Drawing;
    using System.IO;
    using System.Threading;
    using Page = System.Web.UI.Page;
    using Microsoft.Office.Interop.Word;
    using Microsoft.VisualBasic.Devices;
    public partial class ReadIMG : System.Web.UI.Page
    {   
        private Application m_word;
        private int m_i;
        protected void Page_Load(object sender, EventArgs e)
        {
            object missing = Type.Missing;
            object FileName = Server.MapPath("~/LectureOrig/Word.docx");
            object readOnly = true;
            m_word = new Application();
            m_word.Documents.Open(ref FileName,
                                    ref missing, ref readOnly, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing, ref missing,ref missing,ref missing);
            try
            {
                for (int i = 1; i <= m_word.ActiveDocument.InlineShapes.Count; i++)
                {
                    m_i = i;
                   // CopyFromClipboardShape();
                    Thread thread = new Thread(CopyFromClipbordInlineShape);
                    thread.SetApartmentState(ApartmentState.STA);
                    thread.Start();
                    thread.Join();
                }
            }
            finally
            {
                object save = false;
                m_word.Quit(ref save, ref missing, ref missing);
                m_word = null;
            }
        }
        protected void CopyFromClipbordInlineShape()
        {   
            InlineShape inlineShape = m_word.ActiveDocument.InlineShapes[m_i];
            inlineShape.Select();
            m_word.Selection.Copy();
            Computer computer = new Computer();
            //Image img = computer.Clipboard.GetImage();
            if (computer.Clipboard.GetDataObject() != null)
            {
                System.Windows.Forms.IDataObject data = computer.Clipboard.GetDataObject();
                if (data.GetDataPresent(System.Windows.Forms.DataFormats.Bitmap))
                {
                    Image image = (Image)data.GetData(System.Windows.Forms.DataFormats.Bitmap, true);                
                    image.Save(Server.MapPath("~/ImagesGet/image.gif"), System.Drawing.Imaging.ImageFormat.Gif);
                    image.Save(Server.MapPath("~/ImagesGet/image.jpg"), System.Drawing.Imaging.ImageFormat.Jpeg);
                  
                }
                else
                {
                    LabelMessage.Text="The Data In Clipboard is not as image format";
                }
            }
            else
            {
                LabelMessage.Text="The Clipboard was empty";
            }
        }
