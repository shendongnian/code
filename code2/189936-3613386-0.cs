    public override Color BackColor
    {
        set
        {
            if (base.DesignMode)
            {
                if (value != Color.Empty)
                {
                    PropertyDescriptor descriptor = TypeDescriptor.GetProperties(this)["UseVisualStyleBackColor"];
                    if (descriptor != null)
                    {
                        descriptor.SetValue(this, false);
                    }
                }
            }
            else
            {
                this.UseVisualStyleBackColor = false;
            }
            base.BackColor = value;
        }
    }
   
