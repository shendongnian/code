string ToBeReplaceCharacters = @"a;b";
foreach(var RepChar in ToBeReplaceCharacters)
{
  textBox1.Text = textBox1.Text.Replace(RepChar.ToString(), "");
}
What Stackloyd said is ok for single character but not multiple characters to be replaced. The above code fulfils my demand. 
>Thank You All!
