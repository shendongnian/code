lang-csharp
private void ItemDecreased(object sender, EventArgs e)
{
   string textBoxName = HoweverYouGetTheDynamicTextBoxName();
   // Assumptions:
   //   1. ItemDecreased is a method on a Form or a UserControl.
   //   2. There is only one TextBox with the given name in the Form or UserControl.
   //   3. The TextBox is added to the Form or UserControl's Controls property.
   TextBox tb = Controls.Find(textBoxName, true).OfType<TextBox>().SingleOrDefault();
   if (tb is null)
   {
       // Couldn't find the text box for some reason.
   }
   // tb references the dynamically created text box.
}
