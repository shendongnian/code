    using System.Drawing;
    using System.Windows.Forms;//Add Reference.  Test on webserver first.
    Font font = new Font("Calibri", 11.0f, FontStyle.Regular);
    string header  = "Hello There World!";
    int pxBaseline = TextRenderer.MeasureText("__", font).Width;
    int pxHeader   = TextRenderer.MeasureText("_" + header + "_"), font).Width;
    int pxColumnWidth = pxHeader - pxBaseline + 5;//Pad with 5 for Excel.
