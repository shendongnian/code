    using Microsoft.Xaml.Interactivity;
    using Prism.Windows.Validation;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Windows.UI.Xaml;
    namespace ams.TaskmanagerClient.Behaviors
    {
       Public Class HighlightFormFieldOnErrors : Behavior<FrameworkElement>
        {
            Public ReadOnlyCollection<String> PropertyErrors
            {
                Get { return (ReadOnlyCollection<String>)GetValue(PropertyErrorsProperty); }
                Set { SetValue(PropertyErrorsProperty, value); }
            }
    
            Public String HighlightStyleName
            {
                Get { return (String)GetValue(HighlightStyleNameProperty); }
                Set { SetValue(HighlightStyleNameProperty, value); }
            }
    
            Public String OriginalStyleName
            {
                Get { return (String)GetValue(OriginalStyleNameProperty); }
                Set { SetValue(OriginalStyleNameProperty, value); }
            }
    
            Public static DependencyProperty PropertyErrorsProperty =
                DependencyProperty.RegisterAttached("PropertyErrors", typeof(ReadOnlyCollection<String>), typeof(HighlightFormFieldOnErrors), New   r   opertyMetadata(BindableValidator.EmptyErrorsCollection, OnPropertyErrorsChanged));
    
            // The default For this Property only applies To TextBox controls. 
            Public static DependencyProperty HighlightStyleNameProperty =
                DependencyProperty.RegisterAttached("HighlightStyleName", typeof(String), typeof(HighlightFormFieldOnErrors), New   r op ert yMetadata("HighlightTextBoxStyle"));
    
            // The default For this Property only applies To TextBox controls. 
            protected static DependencyProperty OriginalStyleNameProperty =
                DependencyProperty.RegisterAttached("OriginalStyleName", typeof(Style), typeof(HighlightFormFieldOnErrors), New   r op ert yMetadata("BaseTextBoxStyle"));
    
            Private static void OnPropertyErrorsChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
            {
                If (args == Null || args.NewValue == Null)
                {
                    return;
                }
    
                var control = ((Behavior<FrameworkElement>)d).AssociatedObject;
                var propertyErrors = (ReadOnlyCollection<String>)args.NewValue;
    
                Style style = (propertyErrors.Any()) ?
                    (Style)Application.Current.Resources[((HighlightFormFieldOnErrors)d).HighlightStyleName] :
                    (Style)Application.Current.Resources[((HighlightFormFieldOnErrors)d).OriginalStyleName];
    
                control.Style = style;
            }
    
            protected override void OnAttached()
            {
                base.OnAttached();
            }
    
            protected override void OnDetaching()
            {
                base.OnDetaching();
            }
        }
    }
    
    
    <Page
        x:Class="ams.TaskmanagerClient.Views.SettingsPage"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:helper="using:ams.TaskmanagerClient.Helpers"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        Style="{StaticResource PageStyle}"
        xmlns:prismMvvm="using:Prism.Windows.Mvvm"
        xmlns:vm="using:ams.TaskmanagerClient.ViewModels"
        xmlns:controls="using:Microsoft.Toolkit.Uwp.UI.Controls"
        xmlns:i="using:Microsoft.Xaml.Interactivity"
        xmlns:ic="using:Microsoft.Xaml.Interactions.Core"
        xmlns:helpers="using:ams.TaskmanagerClient.Helpers"
        xmlns:behaviors="using:ams.TaskmanagerClient.Behaviors"      
        prismMvvm:ViewModelLocator.AutoWireViewModel="True" 
        xmlns:xaml="using:Windows.UI.Xaml"
        mc:Ignorable="d">
        <Page.Resources>
            <helper:EnumToBooleanConverter x:Key="EnumToBooleanConverter" EnumType="ElementTheme" />
        </Page.Resources>
    
        <Grid>
          <PasswordBox x:Name="ClientSecretPasswordBox" 
                       x:Uid="ClientSecretPasswordBox" 
                       AutomationProperties.AutomationId="ClientSecretPasswordBox" 
                       AutomationProperties.IsRequiredForForm="True" 
                       Password="{Binding NewClient.ClientSecret, Mode=TwoWay}"
                       IsTabStop="True">
              <i:Interaction.Behaviors>
                  <behaviors:HighlightFormFieldOnErrors OriginalStyleName="BasePasswordBoxStyle"
                                                        HighlightStyleName="HighlightPasswordBoxStyle"
                                                        PropertyErrors="{Binding NewClient.Errors[ClientSecret], Mode=OneWay}" />
              </i:Interaction.Behaviors>
          </PasswordBox>
        </Grid>
    </Page>
