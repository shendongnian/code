    //You can get this XAML by using System.Windows.Markup.XamlWriter.Save(yourButton.Template)";
                 const string controlXaml = "<ControlTemplate TargetType=\"ButtonBase\" " +
                                        "xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" " +
                                        "xmlns:s=\"clr-namespace:System;assembly=mscorlib\" " +
                                        "xmlns:mwt=\"clr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero\">" +
                                        "<mwt:ButtonChrome Background=\"{TemplateBinding Panel.Background}\" " +
                                        "BorderBrush=\"{TemplateBinding Border.BorderBrush}\" " +
                                        "RenderDefaulted=\"{TemplateBinding Button.IsDefaulted}\" " +
                                        //"RenderMouseOver=\"{TemplateBinding UIElement.IsMouseOver}\" " +
                                        "RenderPressed=\"{TemplateBinding ButtonBase.IsPressed}\" Name=\"Chrome\" SnapsToDevicePixels=\"True\">" +
                                        "<ContentPresenter RecognizesAccessKey=\"True\" " +
                                        "Content=\"{TemplateBinding ContentControl.Content}\" " +
                                        "ContentTemplate=\"{TemplateBinding ContentControl.ContentTemplate}\" " +
                                        "ContentStringFormat=\"{TemplateBinding ContentControl.ContentStringFormat}\" " +
                                        "Margin=\"{TemplateBinding Control.Padding}\" " +
                                        "HorizontalAlignment=\"{TemplateBinding Control.HorizontalContentAlignment}\" " +
                                        "VerticalAlignment=\"{TemplateBinding Control.VerticalContentAlignment}\" " +
                                        "SnapsToDevicePixels=\"{TemplateBinding UIElement.SnapsToDevicePixels}\" /></mwt:ButtonChrome>" +
                                        "<ControlTemplate.Triggers>" +
                                        "<Trigger Property=\"UIElement.IsKeyboardFocused\">" +
                                        "<Setter Property=\"mwt:ButtonChrome.RenderDefaulted\" TargetName=\"Chrome\"><Setter.Value><s:Boolean>True</s:Boolean></Setter.Value></Setter>" +
                                        "<Trigger.Value><s:Boolean>True</s:Boolean></Trigger.Value></Trigger>" +
                                        "<Trigger Property=\"ToggleButton.IsChecked\">" +
                                        "<Setter Property=\"mwt:ButtonChrome.RenderPressed\" TargetName=\"Chrome\"><Setter.Value><s:Boolean>True</s:Boolean></Setter.Value></Setter>" +
                                        "<Trigger.Value><s:Boolean>True</s:Boolean></Trigger.Value></Trigger>" +
                                        "<Trigger Property=\"UIElement.IsEnabled\"><Setter Property=\"TextElement.Foreground\"><Setter.Value><SolidColorBrush>#FFADADAD</SolidColorBrush></Setter.Value></Setter>" +
                                        "<Trigger.Value><s:Boolean>False</s:Boolean></Trigger.Value></Trigger></ControlTemplate.Triggers>" +
                                        "</ControlTemplate>";
            var xamlStream = new MemoryStream(System.Text.Encoding.Default.GetBytes(controlXaml));
            var _buttonControlTemplate = (ControlTemplate)System.Windows.Markup.XamlReader.Load(xamlStream);
            var yourButton = new Button() { Template = _buttonControlTemplate };
