    public abstract class Note
    {
        public abstract void LoadScaledTex(scale);
    }
    public class NoteA : Note
    {
        private static ScaledTexData instance;
        public override void LoadScaledTex(scale)
        {
            lock(this.GetType())
            {
                if(instance == null)
                {
                    instance = new ScaledTexData(scale);
                }
            }
        }
    }
