            public partial class Form1 : Form
            {
                public Form1()
                {
                    InitializeComponent();
                    //declare path to images directory
                    string path = @"C:\MyPath\images\";
                    //fill an array with file names.
                    string[] images = Directory.GetFiles(path);
                    if (String.IsNullOrEmpty(images[0]))
                    {
                       //set background to hex code color
                    }
                    else if (String.IsNullorEmpty(images[1]))
                    {
                        //set background to images[0]
                    }
                    else
                    {
                        //set background to random array value for images
                    }
                }
            }
