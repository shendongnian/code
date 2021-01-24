 public class Form1 : System.Windows.Forms.Form
   {
      private System.Windows.Forms.CheckedListBox checkedListBox1;
      private List<string> extraVariable;
then in your constructor or wherever you initialize the checkList, also initialize your extra variable:
      public Form1()
      {
         InitializeComponent();
         extraVariable = new List<string>();
Then add your ItemChecked event, where you Add or Remove from your extra variable:
      private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
      {
         if(e.NewValue==CheckState.Unchecked)
         {
            extraVariable.Remove(e.NewValue);
         }
         else
         {
            extraVariable.Add(e.NewValue);
         }
      }
