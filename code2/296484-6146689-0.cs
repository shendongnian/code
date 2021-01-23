    public class Program
    {
        static void Main(string[] args)
        {
            Overlay overlay = new Overlay();
            foreach (FieldInfo field in overlay.GetType().GetFields())
            {
                if(typeof(Control).IsAssignableFrom(field.FieldType))
                {
                    Control c = field.GetValue(overlay) as Control;
                    if(c != null)
                        c.Draw();
                }
            }
        }
    }
