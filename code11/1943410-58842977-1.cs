public void Main(string[] args)
{
	var f1 = new Form1(); // form instance that holds the PictureBox
	
	Task.Run(() => Application.Run(f1)); //I'm running this from LINQPad, but this would also work in a console application.
}
public class Form1 : Form // Derives from the Form class
{
	private bool isX; // private instance variable to indicate which image is diplayed
	private Image x; // private instance variable storing the x image
	private Image o; // private instance variable storing the o image
	
    // the picture box this form uses
	private PictureBox p;
	public Form1()
	{
        // load the images from wherever they are stored.
        // I do this at construction time to avoid doing disk IO when clicking
		x = Image.FromFile(@"C:\image\path\x.png");
		o = Image.FromFile(@"C:\image\path\o.png");
		
        // Initialize the picture box
		p = new PictureBox {
			Name = "p1",
			Size = new Size(100,100),
			Location = new Point(100,100),
			Image = o //Initialize with the o image
		};
		
        // register the click event handler
		p.Click += this.ClickHandle;
		
        // set the flag to false, since the o image is what we start with
		this.isX = false;
		
        // add PictureBox p to the form
		this.Controls.Add(p);
	}
	
    // handles the click action, registered to the PictureBox.Click event
	private void ClickHandle(object sender, EventArgs e)
	{
        // use the flag to check which image is shown, and display the other image
		if(this.isX) // this might work with your image == check, I didn't test it
		{
			p.Image = this.o;
		}
		else
		{
			p.Image = this.x;
		}
        // set the flag to the opposite of whatever the flag currently is
		this.isX = ! isX;
	}
}
[![o image][1]][1]
[![x image][2]][2]
  [1]: https://i.stack.imgur.com/Ge7nL.png
  [2]: https://i.stack.imgur.com/VnPKZ.png
