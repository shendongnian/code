public class Shape : Control
{
}
Then, when you want to add a click event to it just use:
private void SomeMethod()
{
    Shape shape = new Shape();
    shape.Click += Shape_Click;
}
private void Shape_Click(object sender, System.EventArgs e)
{
    // Do Something
}
If you want to make it shorter, you can use this:
Shape shape = new Shape();
shape.Click += (object sender, System.EventArgs e) =>
{
    // Do Something
};
Which does the same thing.
Good luck!
