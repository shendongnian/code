    public partial class Form1 : Form
    {
        Dictionary<string, string> keylist = new Dictionary<string, string>();       
        public Form1()
        {
            InitializeComponent();
        }
        public void YourFunction(string intext)
        {
            if (intext.Contains("addkey") && intext.Contains("def"))        
            {            
                string[] keywords = intext.Split(' ');            
                string key1 = keywords[1];            
                string def2 = keywords[3];            
                string fkey = key1.Replace("_", " ");            
                string fdef = def2.Replace("_", " ");            
                keylist.Add(fkey, fdef);            
                say("Phrase '" + fkey + "' added with response '" + fdef + "'");            
                say("Your Dictionary contains " + keylist.Count.ToString() + " word(s)."); 
            }
        }
    }
