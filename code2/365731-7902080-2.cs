    public class SoundList : ResourceList<Sound>
    {
        protected override Sound LoadImpl(string name)
        {
             return Resources.LoadSound(name);
        }
    }
