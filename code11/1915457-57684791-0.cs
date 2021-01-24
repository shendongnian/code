private Image Image { get; }
public Managers(Image image)
{
    //...//
    Image = image;
    //...//
}
Your consuming class will then create it via `var managers = new Managers(Image.FromFile("exit.png"));`
Now you can use a library like [Moq][1] to create a mock image.
[TestMethod]
public void initTest1()
{
    var image = new Mock<Image>();
    Assert.IsNotNull(new Managers(image.Object));
}
  [1]: https://github.com/moq/moq4
