c#
namespace OpenTK_example_1
{
    public class OpenTK_Window
        : GameWindow
    {
        OpenTK_Window(int width, int height, string title)
            : base(width, height, new GraphicsMode(32, 24, 8, 8), title,
        {}
        // [...]
    }
}
In this case the 4th parameter to the constructor of `GraphicsMode` is the number of samples.
