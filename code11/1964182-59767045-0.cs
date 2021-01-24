checkBox.CheckedChange += OnCheckedChange;
private void OnCheckedChange(object sender, RadioGroup.CheckedChangeEventArgs e)
{
        //include your code logic here
}
Or you could use lambda directly
checkBox.CheckedChange += (s, e) =>
{
    //include your logic here
    //s = sender (checkbox)
    //e = RadioGroup.CheckedChangeEventArgs
};
