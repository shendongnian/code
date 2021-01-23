    public class TextureList : ResourceList<Texture>
    {
        protected override Texture LoadImpl(string name)
        {
            return Resources.LoadImage(name);
        }
    }
