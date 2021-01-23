    namespace App1_Name
    {
        public partial class Form1 : Form
        {
            public cConfig Config = new cConfig();
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
            cXML XML = new cXML();
            XML.Config = Config; //Passing the Config Class by Reference to cXML
        }
    }
