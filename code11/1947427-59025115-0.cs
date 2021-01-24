c#
public IEnumerable<Control> GetControlOfTag(Control container, string tag)
{
    var ctrls = container.Controls.Cast<Control>();
    return ctrls.SelectMany(c => GetControlOfTag(c, tag)).Concat(ctrls.Where(c => c.Tag != null && c.Tag.ToString().Equals(tag)));
}
From any caller:
c#
private void button1_Click(object sender, EventArgs e)
{
    var controls = GetControlOfTag(this, "Tag_text_To_Find");
}
Good Luck.
