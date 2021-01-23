    public class CustomMetroForm : MetroForm
    {
        public CustomMetroForm()
        {
            this.Load += this.OnLoad;
        }
        public virtual void OnLoad(object sender, EventArgs eventArgs)
        {
            foreach (var descendant in this.Descendants<Panel>().Where(x => x.BackColor == Color.FromArgb(255, 216, 216, 216)))
            {
                descendant.BackColor = Color.White;
            }
        }
    }
    public static class ControlExtensions
    {
        public static IEnumerable<T> Descendants<T>(this Control control) where T : class 
        { 
            foreach (Control child in control.Controls) 
            { 
                var childOfT = child as T; 
                
                if (childOfT != null) 
                { 
                    yield return childOfT; 
                }
 
                if (child.HasChildren) 
                { 
                    foreach (var descendant in Descendants<T>(child)) 
                    { 
                        yield return descendant; 
                    } 
                } 
            } 
        }
    }
