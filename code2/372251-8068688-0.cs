    [System.Runtime.InteropServices.ComVisible(true)]
    public partial class Form1 : Form
    {
        [System.Runtime.InteropServices.ComVisible(true)]    
        public class Person
        {
            public int Status = 9;
        }
        public Person person = new Person();
        
        private void Form1_Load(object sender, EventArgs e)
        {
            MSScriptControl.ScriptControlClass script = new MSScriptControl.ScriptControlClass();
            script.Language = "JavaScript";
            
            script.AddObject("myform", this,true); 
            var b =  script.Eval("myform.person.Status==9");
        }
    }
