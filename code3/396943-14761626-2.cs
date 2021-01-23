    /// <summary>
    /// Set the maximum length of a TextBox based on any StringLength attribute of the bound property
    /// </summary>
    public class RestrictStringInputBehavior : Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            AssociatedObject.Loaded += (sender, args) => setMaxLength();
            base.OnAttached();
        }
        private void setMaxLength()
        {
            object context = AssociatedObject.DataContext;
            BindingExpression binding = AssociatedObject.GetBindingExpression(TextBox.TextProperty);
            if (context != null && binding != null)
            {
                PropertyInfo prop = context.GetType().GetProperty(binding.ParentBinding.Path.Path);
                if (prop != null)
                {
                    var att = prop.GetCustomAttributes(typeof(StringLengthAttribute), true).FirstOrDefault() as StringLengthAttribute;
                    if (att != null)
                    {
                        AssociatedObject.MaxLength = att.MaximumLength;
                    }
                }
            }
        }
    }
