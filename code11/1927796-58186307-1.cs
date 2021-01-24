lang-csharp
private void CreateLabels()
{
   for (int i = 0; i < numericUpDown1.Value; i++)
   {
      Label l = new Label();
      l.Name = $"DynamicLabel{i}";
      l.Text = "_";
      l.Width = 20;
      l.Height = 25;
      l.Left = i * 20 + 510;
      l.Top = 20;
      l.BackColor = Color.Transparent;
      groupBox2.Controls.Add(l);
   }
}
private void DoSomethingWithADynamicLabel(int dynamicLabelIndex)
{
   Label l = groupBox2.Controls.Find($"DynamicLabel{i}", true).FirstOrDefault() as Label;
   if (l is null)
   {
      // Couldn't find the label...
      return;
   }
   // Do something with l
}
When creating the `Label` instances inside `CreateLabels`, I'm simply appending the `for` loop's counter to the string `"DynamicLabel"`. This gives you a bunch of `Label`s with names like `"DynamicLabel0"`, `"DynamicLable1"`, `"DynamicLabel2`", etc...
Then in `DoSomethingWithADynamicLabel`, assuming you have the index of the `Label` you want to deal with, you can use `groupBox2.Controls.Find` to actually find the `Label` you're interested in.
