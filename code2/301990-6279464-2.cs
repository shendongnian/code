    <Page xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
          xmlns:sys="clr-namespace:System;assembly=mscorlib"
          xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
      <Page.Resources>
        <Style x:Key="RBToggleButtonStyle" TargetType="{x:Type RadioButton}">
          <Setter Property="Template">
             <Setter.Value>
        	   <ControlTemplate>
                 <ToggleButton
                     IsChecked="{Binding IsChecked, RelativeSource={RelativeSource TemplatedParent}, Mode=TwoWay}"
                     Content="{Binding Content, RelativeSource={RelativeSource TemplatedParent}, Mode=TwoWay}" />
               </ControlTemplate>
             </Setter.Value>
           </Setter>
           <Setter Property="Width" Value="150"/>
           <Setter Property="Height" Value="25"/>
           <Setter Property="HorizontalAlignment" Value="Right"/>
           <Setter Property="VerticalAlignment" Value="Bottom"/>
           <Setter Property="Margin" Value="15"/>
           <Setter Property="Content" Value="Hide"/>
        </Style>
      </Page.Resources>
      <Grid>
        <Grid.ColumnDefinitions>
          <ColumnDefinition/>
          <ColumnDefinition/>
        </Grid.ColumnDefinitions>
        <Border Background="Green" Grid.Column="0" x:Name="green">
          <Border.Style>
            <Style TargetType="Border">
              <Style.Triggers>
                <DataTrigger Binding="{Binding IsChecked, ElementName=greenB}" Value="True">
                  <Setter Property="Visibility" Value="Hidden"/>
                </DataTrigger>
              </Style.Triggers>
            </Style>
          </Border.Style>
          <RadioButton x:Name="greenB" GroupName="x" Style="{StaticResource RBToggleButtonStyle}"/>
        </Border>
        <Border Background="Red" Grid.Column="1" x:Name="red">
          <Border.Style>
            <Style TargetType="Border">
              <Style.Triggers>
                <DataTrigger Binding="{Binding IsChecked, ElementName=redB}" Value="True">
                  <Setter Property="Visibility" Value="Hidden"/>
                </DataTrigger>
              </Style.Triggers>
            </Style>
          </Border.Style>
          <RadioButton x:Name="redB" GroupName="x" Style="{StaticResource RBToggleButtonStyle}"/>
        </Border>
      </Grid>
    </Page>
