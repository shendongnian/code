C#
for (int i = 0; i < lines.Length; i++)
{
    textsplit = lines[i].Split('@');
    for (int j = 0; j < textsplit.Length; j++)
    {
        MessageBox.Show(textsplit[0]);
        break;
    }
}
and it works!
Edit: so it won't need any `for`/`foreach` statements.
for (int i = 0; i < lines.Length; i++)
{
    textsplit = lines[i].Split('@');
    MessageBox.Show(textsplit[0]);
}
Just do this, and it will be fine.
Thanks PeterDuniho for the help!
