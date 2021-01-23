    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    namespace waTest
    {
        public partial class Form1 : Form
        {
            [DllImport("Kernel32.dll")]
            static extern Boolean AllocConsole( );
            public Form1( )
            {
                InitializeComponent();
            }
    
            private void Form1_Load( object sender, EventArgs e )
            {
                if ( !AllocConsole() )
                     MessageBox.Show("Failed");
                Console.WriteLine("test");
                string input = Console.ReadLine();
                MessageBox.Show(input);
                    
    
    
    
            }
        }
    }
