     public partial class Form1 : Form
            {
            Button[] btn = new Button[12];// <--------<<<Button Array
    
            public Form1 ( )
             {   
                InitializeComponent ( );
             {      
             }       
             }   
            private void Form1_Load ( object sender, EventArgs e )
              {    
              for (int i = 0; i < 12; i++)
              { btn[i] = new Button ( ); 
               this.flowLayoutPanel1.Controls.Add(btn[i]);
         
              }
            }
            // double click on the flow layoutPannel initiates this code
            private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
            {
            
            }
          
      }}
                   
