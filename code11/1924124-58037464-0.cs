    public partial class Form1: Form
    {
      Form2 f2;//you can remove this as a class wide variable and just instantiate it locally in the double click because you don't reuse it
        public Dictionary<string, string[]> RecipeDict {get; set;} //make it a property by putting a get/set, capitalise the firt letter of public members
        
        //remove formttedCell
        public Dictionary<string, string[]> FormattedCell {get;set}
