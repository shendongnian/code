var result = dr.Field<int?>("intCol");
txtField.Text = result;
You should not use `static` for your model class.
public class YourModel
{
    public string Email { get; set; }
}
