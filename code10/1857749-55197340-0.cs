                public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
                {
                    IWindowsFormsEditorService service = provider.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;
        
                    Type type = context.GetType();
                    PropertyInfo property = type.GetProperty("OwnerGrid");
        
                    IPlugIn plug = context.Instance as IPlugIn;
        
                    if (service != null && property != null
                                        && plug != null)
                    {
                        PropertyGrid owner = property.GetValue(context) as PropertyGrid;
        
                        if (owner != null)
                        {
                            Collection<VariableWrapper> variables = owner.Tag as Collection<VariableWrapper>;
        
                            if (variables != null)
                            {
                                VariableEditorForm editor = new VariableEditorForm();
                                editor.Value = plug.VariableName;
                                editor.Variables = variables.Select(o => o.Variable).Where(o => o.ValueType == plug.VariableType).ToArray();
                                editor.TopLevel = false;
                                editor.FormClosed += new FormClosedEventHandler((sender, args) =>
                                {
                                    // disable main form rendering
                                    User32.PostMessage(Process.GetCurrentProcess().MainWindowHandle, Messages.WM_DISABLE_RENDER, IntPtr.Zero, IntPtr.Zero);
                                    service.CloseDropDown();
                                });
        
                                service.DropDownControl(editor);
                                
                                // enable main form rendering
                                User32.PostMessage(Process.GetCurrentProcess().MainWindowHandle, Messages.WM_ENABLE_RENDER, IntPtr.Zero, IntPtr.Zero);
                                value = editor.Value;
                                editor.Dispose();
                            }
                        }
                    }
        
                    return value;
                }
