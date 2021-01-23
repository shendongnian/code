    public partial class YourFirstForm
    {
        // example to expose a method on first form and pass IN a value
        public void SetMyObject( string ValueFromSecondForm )
        {
           this.txtBox1.Text = ValueFromSecondForm;
        }
    
        // example via a property you are trying to set... identical in results
        public string ViaSetAsProperty
        { set { this.txtBox1.Text = value; } }
    
        // Now, the reverse, lets expose some things from form 1 to the second...
        public string GetMyObjectText()
        {
           return this.txtBox1.Text;
        } 
        
        // or via a GETTER property... 
        public string GettingText
        { get { return this.txtBox1.Text; } }
    
    
        // However, if you want to allow both set and get to form 1's values, 
        // do as a single property with both getter / setter exposed..
        public string TextContent
        {  get { return this.txtBox1.Text; }
           set { this.txtBox1.text = value; }
        }
    }
