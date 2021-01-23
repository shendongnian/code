    using Microsoft.VisualBasic.PowerPacks;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            Random random = new Random();
            
            public Form1()
            {    
                InitializeComponent();
            }
    
            private void ovalShape1_Click(object sender, EventArgs e)
            {        
                ovalShape1.BackStyle = BackStyle.Opaque;
                
                random = new Random();
               
                ovalShape1.BackColor = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
           
             }
         }
     }
