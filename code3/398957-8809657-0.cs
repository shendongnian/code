    public partial class Dropshadow : Form
    {
        
        public Dropshadow(Form parentForm)
        {
            /*This bit of code makes the form click-through. 
              So you can click forms that are below it in z-space */
            int wl = GetWindowLong(this.Handle, -20);
            wl = wl | 0x80000 | 0x20;
            SetWindowLong(this.Handle, -20, wl);
            InitializeComponent();
            
            //Makes the start location the same as parent.
            this.StartPosition = parentForm.StartPosition;
            parentForm.Activated += ParentForm_Activated; //Fires on parent activation to do a this.BringToFront() 
            this.Deactivate += This_Deactivated; //Toggles a boolean that ensures that ParentForm_Activated does fire when clicking through (this)
            parentForm.Closed += ParentForm_Closed; //Closes this when parent closes
            parentForm.Move += ParentForm_Move; //Follows movement of parent form
            //Draws border with standard bitmap modifications and merging
            /* Omitted function to avoid extra confusion */
            Bitmap getShadow = DrawBlurBorder(parentForm.ClientSize.Width, parentForm.ClientSize.Height);
            /* **This code was featured in the original post:** */
            SetBitmap(getShadow, 255); //Sets background as 32-bit image with full alpha.
            this.Location = Offset; //Set within DrawBlurBorder creates an offset 
        }
        private void ParentForm_Activated(object o, EventArgs e)
        {
            /* Sets this form on top when parent form is activated.*/
            if (isBringingToFront)
            { 
                /*Hopefully prevents recusion*/
                isBringingToFront = false;
                return;
            }
            
            this.BringToFront();
            /* Some special tweaks omitted to avoid confusion */
        }
        private void This_Deactivated(object o, EventArgs e)
        {
            /* Prevents recusion. */
            isBringingToFront = true;
        }
        /* Closes this when parent form closes. */
        private void ParentForm_Closed(object o, EventArgs e)
        {
            this.Close();
        }
        /* Adjust position when parent moves. */
        private void ParentForm_Move(object o, EventArgs e)
        {
            if(o is Form)
                this.Location = new Point((o as Form).Location.X + Offset.X, (o as Form).Location.Y + Offset.Y);
        }
     }
