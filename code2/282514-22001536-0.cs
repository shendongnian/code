    public class cExample
    {
        ...
        Random randomGen = new Random();
        KnownColor[] names = (KnownColor[]) Enum.GetValues(typeof(KnownColor));
        ...
        private Color get_random_color()
        {
             KnownColor randomColorName = names[randomGen.Next(names.Length)];
             return Color.FromKnownColor(randomColorName);
        }
        ...
    }
