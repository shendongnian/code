double ans = 0;
try
{
    ans = int.Parse(myInput1.Text) / double.Parse(myInput2.Text);
    MessageBox.Show("The values being divided are " + myInput1.Text + "/" + myInput2.Text + "=" + ans);
}
catch (Exception ex)
{
    myInput1.Text = "0";
    myInput2.Text = "0";
}
