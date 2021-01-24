    class Object
    {
        private PictureBox Imageof = new PictureBox();
        private Form1 _form1;
        //Parameters
        protected int Id { get; set; }
        protected string Name { get; set; }
        protected string Image { get; set; }
        protected bool Collision { get; set; }
        protected string Location { get; }
        //Constructor
        public Object(Form1 form1,
            int Id, string Name, string Image, bool Collision, string Location)
        {
            this.Id = Id;
            this.Name = Name;
            this.Image = Image;
            this.Collision = Collision;
            this.Location = Location;
            Imageof.Image =     System.Drawing.Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + Image + ".png");
            _form1 = form1;
            _form1.panel1.Controls.Add(Imageof);
        }
    }
