    /*
     * Copyright - Everyone can use this code for any reason yet if you find a bug, I do not hold myself responsable :D
     */
    using System.Windows.Data;
    using System.Windows.Markup;
    
    namespace BindableParameterExtension
    {
        /// <summary>
        /// BindableParameter is the class that changes the ConverterParameter Value
        /// This must inherit from freezable so that it can be in the inheritance context and thus be able to use the DataContext and to specify ElementName binding as a ConverterParameter
        /// http://www.drwpf.com/Blog/Default.aspx?tabid=36&EntryID=36
        /// </summary>
        public class BindableParameter : Freezable
        {
            #region fields
            //this is a hack to trick the WPF platform in thining that the binding is not sealed yet and then change the value of the converter parameter
            private static FieldInfo isSealedFieldInfo;
            #endregion
    
            #region Properties
            #region Parameter
    
            /// <summary>
            /// Parameter Dependency Property
            /// </summary>
            public static readonly DependencyProperty ParameterProperty =
                DependencyProperty.Register("Parameter", typeof(object), typeof(BindableParameter),
                    new FrameworkPropertyMetadata((object)null,
                        (d, e) =>
                        {
                            BindableParameter param = (BindableParameter)d;
                            //set the ConverterParameterValue before calling invalidate because the invalidate uses that value to sett the converter paramter
                            param.ConverterParameterValue = e.NewValue;
                            //update the converter parameter 
                            InvalidateBinding(param);
                        }
                        ));
    
            /// <summary>
            /// Gets or sets the Parameter property.  This dependency property 
            /// indicates ....
            /// </summary>
            public object Parameter
            {
                get { return (object)GetValue(ParameterProperty); }
                set { SetValue(ParameterProperty, value); }
            }
    
            #endregion
    
            #region BindParameter
    
            /// <summary>
            /// BindParameter Attached Dependency Property
            /// </summary>
            public static readonly DependencyProperty BindParameterProperty =
                DependencyProperty.RegisterAttached("BindParameter", typeof(BindableParameter), typeof(BindableParameter),
                    new FrameworkPropertyMetadata((BindableParameter)null,
                        new PropertyChangedCallback(OnBindParameterChanged)));
    
            /// <summary>
            /// Gets the BindParameter property.  This dependency property 
            /// indicates ....
            /// </summary>
            public static BindableParameter GetBindParameter(DependencyObject d)
            {
                return (BindableParameter)d.GetValue(BindParameterProperty);
            }
    
            /// <summary>
            /// Sets the BindParameter property.  This dependency property 
            /// indicates ....
            /// </summary>
            public static void SetBindParameter(DependencyObject d, BindableParameter value)
            {
                d.SetValue(BindParameterProperty, value);
            }
    
            /// <summary>
            /// Handles changes to the BindParameter property.
            /// </summary>
            private static void OnBindParameterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                FrameworkElement element = d as FrameworkElement;
                if (element == null)
                    throw new InvalidOperationException("BindableParameter can be applied to a FrameworkElement only");
    
                BindableParameter parameter = (BindableParameter)e.NewValue;
                element.Initialized += delegate
                {
                    parameter.TargetExpression = BindingOperations.GetBindingExpression(element, parameter.TargetProperty);
                    parameter.TargetBinding = BindingOperations.GetBinding(element, parameter.TargetProperty);
    
                    //update the converter parameter 
                    InvalidateBinding(parameter);
                };
            }
    
            #endregion
    
            public object ConverterParameterValue { get; set; }
    
            public BindingExpression TargetExpression { get; set; }
    
            public Binding TargetBinding { get; private set; }
    
            /// <summary>
            /// Gets the object being bound
            /// </summary>
            public DependencyObject TargetObject { get; private set; }
    
            /// <summary>
            /// Gets the dependency property being bound
            /// </summary>
            public DependencyProperty TargetProperty { get; internal set; }
            #endregion
    
            /// <summary>
            /// Static constructor to get the FieldInfo meta data for the _isSealed field of the BindingBase class
            /// </summary>
            static BindableParameter()
            {
                //initialize the field info once
                isSealedFieldInfo =
                    typeof(BindingBase).GetField("_isSealed", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
    
                if (isSealedFieldInfo == null)
                    throw new InvalidOperationException("Oops, we have a problem, it seems like the WPF team decided to change the name of the _isSealed field of the BindingBase class.");
    
            }
    
            private static void InvalidateBinding(BindableParameter param)
            {
                if (param.TargetBinding != null && param.TargetExpression != null)
                {
                    //this is a hack to trick the WPF platform in thining that the binding is not sealed yet and then change the value of the converter parameter
                    bool isSealed = (bool)isSealedFieldInfo.GetValue(param.TargetBinding);
    
                    if (isSealed)//change the is sealed value
                        isSealedFieldInfo.SetValue(param.TargetBinding, false);
    
                    param.TargetBinding.ConverterParameter = param.ConverterParameterValue;
    
                    if (isSealed)//put the is sealed value back as it was...
                        isSealedFieldInfo.SetValue(param.TargetBinding, true);
    
                    //force an update to the binding
                    param.TargetExpression.UpdateTarget();
                }
            }
    
            #region Freezable Stuff
            protected override Freezable CreateInstanceCore()
            {
                //throw new NotImplementedException();
                //return _bindableParam;
    
                return this;
            }
            #endregion
    
        }
    
        /// <summary>
        /// Markup extension so that it is easier to create an instance of the BindableParameter from XAML
        /// </summary>
        [MarkupExtensionReturnType(typeof(BindableParameter))]
        public class BindableParameterExtension : MarkupExtension
        {
            /// <summary>
            /// Gets or sets the Dependency property you want to change the binding's ConverterParameter
            /// </summary>
            public DependencyProperty TargetProperty { get; set; }
    
            /// <summary>
            /// Gets or sets the Binding that you want to use for the converter parameter
            /// </summary>
            public Binding Binding { get; set; }
    
            /// <summary>
            /// constructor that accepts a Dependency Property so that you do not need to specify TargetProperty
            /// </summary>
            /// <param name="property">The Dependency property you want to change the binding's ConverterParameter</param>
            public BindableParameterExtension(DependencyProperty property)
            {
                TargetProperty = property;
            }
    
            public BindableParameterExtension()
            { }
    
            public override object ProvideValue(IServiceProvider serviceProvider)
            {
                _bindableParam = new BindableParameter();
                //set the binding of the parameter
                BindingOperations.SetBinding(_bindableParam, BindableParameter.ParameterProperty, Binding);
                _bindableParam.TargetProperty = TargetProperty;
                return _bindableParam;
            }
    
            private BindableParameter _bindableParam;
    
        }
    }
