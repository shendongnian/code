    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Drawing.Imaging;
    static class Program {
    [STAThread]
    static void Main() {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Form1());
    }
    }
    public class Form1 : Form {
    private Bitmap _myImage = new Bitmap(@"C:\Users\Public\Pictures\Sample   Pictures\LightHouse.jpg");
    private int _scale = 10; // keep this < 15
    private PictureBox pboxMain;
    private PictureBox pboxZoom;
    private System.ComponentModel.IContainer components;
    public Form1() {
        InitializeComponent();
    }
    private void Form1_Load(object sender, EventArgs e) {
        pboxMain.Image = _myImage;
    }
    private void pboxMain_MouseMove(object sender, MouseEventArgs e) {
        try {
            Rectangle rc = new Rectangle(
                new Point(e.X - _scale, e.Y - _scale),
                new Size(_scale * 2, _scale * 2));
            pboxZoom.Image = _myImage.Clone(rc, PixelFormat.DontCare);
        }
        catch (OutOfMemoryException  ex) {/* ignore... */}
    }
    protected override void Dispose(bool disposing) {
        if (disposing && (components != null)) {
            components.Dispose();
        }
        base.Dispose(disposing);
    }
    private void InitializeComponent() {
        this.pboxMain = new PictureBox();
        this.pboxZoom = new PictureBox();
        ((System.ComponentModel.ISupportInitialize)(this.pboxMain)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.pboxZoom)).BeginInit();
        this.SuspendLayout();
        this.pboxMain.Dock = DockStyle.Fill;
        this.pboxMain.Location = new System.Drawing.Point(0, 0);
        this.pboxMain.Name = "pboxMain";
        this.pboxMain.Size = new System.Drawing.Size(767, 435);
        this.pboxMain.TabIndex = 0;
        this.pboxMain.TabStop = false;
        this.pboxMain.MouseMove += new MouseEventHandler(this.pboxMain_MouseMove);
        this.pboxZoom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))),
      ((int)(((byte)(255)))), ((int)(((byte)(192)))));
        this.pboxZoom.BorderStyle = BorderStyle.FixedSingle;
        this.pboxZoom.Location = new System.Drawing.Point(12, 12);
        this.pboxZoom.Name = "pboxZoom";
        this.pboxZoom.Size = new System.Drawing.Size(106, 83);
        this.pboxZoom.SizeMode = PictureBoxSizeMode.StretchImage;
        this.pboxZoom.TabIndex = 1;
        this.pboxZoom.TabStop = false;
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(767, 435);
        this.Controls.Add(this.pboxZoom);
        this.Controls.Add(this.pboxMain);
        this.Name = "Form1";
        this.Text = "Form1";
        this.Load += new System.EventHandler(this.Form1_Load);
        ((System.ComponentModel.ISupportInitialize)(this.pboxMain)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.pboxZoom)).EndInit();
        this.ResumeLayout(false);
    }
}
