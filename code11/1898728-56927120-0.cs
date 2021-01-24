public class myForm : Form
{
    public float myFloat { get; set; } = 2.78f;
    public string myString { get; set; } = "127";
    private void button2_Click(object sender, EventArgs e)
    {
        //Get "myFloat" property of this instance of Form.
        PropertyInfo myfloat_property = this.GetType().GetProperty("myFloat");
        //Get ToString(IFormatProvider) method of the "myFloat" property.
        MethodInfo to_string = myfloat_property.PropertyType.GetMethod("ToString", new Type[] { typeof(IFormatProvider) });
        //Set "myString" property. Where i get the exception.
        myString = (string)to_string.Invoke(myfloat_property.GetValue(this), new object[] { CultureInfo.InvariantCulture });
    }
}
Now, that said, there are a couple of things unclear in your question. The above code would fix the exception. But it hardly seems like the best way to achieve the final result. For example, you already have access to the property itself, so rather than using the `PropertyInfo` object, you could just use the property directly:
public class myForm : Form
{
    public float myFloat { get; set; } = 2.78f;
    public string myString { get; set; } = "127";
    private void button2_Click(object sender, EventArgs e)
    {
        //Get ToString(IFormatProvider) method of the "myFloat" property.
        MethodInfo to_string = myFloat.GetType().GetMethod("ToString", new Type[] { typeof(IFormatProvider) });
        //Set "myString" property. Where i get the exception.
        myString = (string)to_string.Invoke(myFloat, new object[] { CultureInfo.InvariantCulture });
    }
}
But even that seems overly complicated. After all, not only is the property accessible, the `ToString()` method is as well. So your method could in fact look like this:
public class myForm : Form
{
    public float myFloat { get; set; } = 2.78f;
    public string myString { get; set; } = "127";
    private void button2_Click(object sender, EventArgs e)
    {
        myString = myFloat.ToString(CultureInfo.InvariantCulture);
    }
}
No reflection needed at all. And no exceptions. :)
