    var modifiedXaml = @"<DockPanel xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
                                    xmlns:s=""clr-namespace:System;assembly=mscorlib"" 
                                    xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml"">
                    <DockPanel.Resources>
                        <s:Boolean x:Key=""BooleanTrue"">True</s:Boolean>
                        <Style TargetType=""TextBox"">
                            <Style.Triggers>
                                <Trigger Property=""IsReadOnly"" Value=""{StaticResource BooleanTrue}"">
                                    <Setter Property=""Background"" Value=""#FFEEEEEE"" />
                                </Trigger>
                            </Style.Triggers>
                        </Style>
                    </DockPanel.Resources>
                    <TextBox IsReadOnly=""True"" />
                </DockPanel>";
    var originalXaml = @"<DockPanel xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
                                    xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml"">
    	            <DockPanel.Resources>
    		            <Style TargetType=""TextBox"">
    			            <Style.Triggers>
    				            <Trigger Property=""IsReadOnly"" Value=""True"">
    					            <Setter Property=""Background"" Value=""#FFEEEEEE"" />
    				            </Trigger>
    			            </Style.Triggers>
    		            </Style>
    	            </DockPanel.Resources>
    	            <TextBox IsReadOnly=""{Binding}""/>
                </DockPanel>";
    try
    {
        // If this line is executed, no `XamlParseException` is thrown
        var root = XamlReader.Parse(modifiedXaml);
        var root2 = XamlReader.Parse(originalXaml);
    }
    catch (XamlParseException ex)
    {
    }
