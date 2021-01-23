    <sap:ActivityDesigner x:Class="ARIASquibLibrary.Design.TestArrayActivityDesigner"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:sap="clr-namespace:System.Activities.Presentation;assembly=System.Activities.Presentation"
    xmlns:sapc="clr-namespace:System.Activities.Presentation.Converters;assembly=System.Activities.Presentation"  
    xmlns:sapv="clr-namespace:System.Activities.Presentation.View;assembly=System.Activities.Presentation" Collapsible="False">
    <sap:ActivityDesigner.Resources>
        <ResourceDictionary>
            <sapc:ArgumentToExpressionConverter x:Key="ArgumentToExpressionConverter" />
        </ResourceDictionary>
    </sap:ActivityDesigner.Resources>
    <Grid>
        <sapv:ExpressionTextBox  
                MaxWidth="150" 
                MinWidth="150" 
                Margin="5"
                OwnerActivity="{Binding Path=ModelItem}"
                Expression="{Binding Path=ModelItem.StringsList, Mode=TwoWay,
                Converter={StaticResource ArgumentToExpressionConverter},
                ConverterParameter=In }"/>
    </Grid>
