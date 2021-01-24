class Form1
{
   private void BtnModify_Click(object sender, EventArgs e)
   {
      var ruleData = ..... //get current rule data
      var rulesForm = new Rules();
      rulesForm.SetData(ruleData); //pass initial state to the form
      rulesForm.SaveChanges = this.ApplyRules; //pass a method which will be called on save
      rulesForm.Show();
   }
   private bool ApplyRules(RuleData ruleData)
   {
       //do whatever you like with the rules here
       return true;
   }
}
class RuleForm
{
   public void SetData(RuleData ruleData)
   {
      //initialize fields, etc
   }
   public Func<RuleData, bool> SaveChanges { get; set; }
   private void BtnSave_Click(object sender, EventArgs e)
   {
       var ruleData = .... //get data from form fields
       if(this.SaveChanges(ruleData))
           this.Close();
   }
}
class RuleData
{
 //whatever data you need
}
