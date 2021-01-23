    public class ReferencesCollectionEditor : UITypeEditor
    {
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            List<Control> available = new List<Control>();
            ButtonActivityControl control = context.Instance as ButtonActivityControl;
            IDesignerHost host = provider.GetService(typeof(IDesignerHost)) as IDesignerHost;
            IComponent componentHost = host.RootComponent;
            if (componentHost is ContainerControl)
            {
                Queue<ContainerControl> containers = new Queue<ContainerControl>();
                containers.Enqueue(componentHost as ContainerControl);
                while (containers.Count > 0)
                {
                    ContainerControl container = containers.Dequeue();
                    foreach (Control item in container.Controls)
                    {
                        if (item != null && context.PropertyDescriptor.PropertyType.GetElementType().IsAssignableFrom(item.GetType()))
                            available.Add(item);
                        if (item is ContainerControl)
                            containers.Enqueue(item as ContainerControl);
                    }
                }
            }
            // collecting buttons in form
            Control[] selected = (Control[])value;
            // show editor form
            ReferencesCollectionEditorForm form = new ReferencesCollectionEditorForm(available.ToArray(), selected);
            form.ShowDialog();
            // save new value
            Array result = Array.CreateInstance(context.PropertyDescriptor.PropertyType.GetElementType(), form.Selected.Length);
            for (int it = 0; it < result.Length; it++)
                result.SetValue(form.Selected[it], it);
            return result;
        }
    }
