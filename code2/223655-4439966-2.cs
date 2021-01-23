    <Style x:Key="DatePickerStyle" TargetType="controls:DatePicker">
       <Setter Property="IsTabStop" Value="False"/>
       <Setter Property="Background" Value="#FFFFFFFF"/>
       <Setter Property="Padding" Value="2"/>
       <Setter Property="SelectionBackground" Value="#FF444444"/>
       <Setter Property="BorderBrush">
          <Setter.Value>
             <LinearGradientBrush EndPoint=".5,0" StartPoint=".5,1">
                <GradientStop Color="#FF617584" Offset="0"/>
                <GradientStop Color="#FF718597" Offset="0.375"/>
                <GradientStop Color="#FF8399A9" Offset="0.375"/>
                <GradientStop Color="#FFA3AEB9" Offset="1"/>
             </LinearGradientBrush>
          </Setter.Value>
       </Setter>
       <Setter Property="BorderThickness" Value="1"/>
       <Setter Property="Template">
          <Setter.Value>
             <ControlTemplate TargetType="controls:DatePicker">
                <Grid x:Name="Root">
                   <Grid.Resources>
                      <SolidColorBrush x:Key="DisabledBrush" Color="#8CFFFFFF"/>
                      <ControlTemplate x:Key="DropDownButtonTemplate" TargetType="Button">
                         <Grid>
                            <VisualStateManager.VisualStateGroups>
                               <VisualStateGroup x:Name="CommonStates">
                                  <VisualStateGroup.Transitions>
                                     <VisualTransition GeneratedDuration="0"/>
                                     <VisualTransition GeneratedDuration="0:0:0.1" To="MouseOver"/>
                                     <VisualTransition GeneratedDuration="0:0:0.1" To="Pressed"/>
                                  </VisualStateGroup.Transitions>
                                  <VisualState x:Name="Normal"/>
                                  <VisualState x:Name="MouseOver">
                                     <Storyboard>
                                        <ColorAnimation Duration="0" Storyboard.TargetName="Background" Storyboard.TargetProperty="(Border.Background).(SolidColorBrush.Color)" To="#FF448DCA"/>
                                        <ColorAnimationUsingKeyFrames BeginTime="0" Duration="00:00:00.001" Storyboard.TargetName="BackgroundGradient" Storyboard.TargetProperty="(Border.Background).(GradientBrush.GradientStops)[3].(GradientStop.Color)">
                                           <SplineColorKeyFrame KeyTime="0" Value="#7FFFFFFF"/>
                                        </ColorAnimationUsingKeyFrames>
                                        <ColorAnimationUsingKeyFrames BeginTime="0" Duration="00:00:00.001" Storyboard.TargetName="BackgroundGradient" Storyboard.TargetProperty="(Border.Background).(GradientBrush.GradientStops)[2].(GradientStop.Color)">
                                           <SplineColorKeyFrame KeyTime="0" Value="#CCFFFFFF"/>
                                        </ColorAnimationUsingKeyFrames>
                                        <ColorAnimationUsingKeyFrames BeginTime="0" Duration="00:00:00.001" Storyboard.TargetName="BackgroundGradient" Storyboard.TargetProperty="(Border.Background).(GradientBrush.GradientStops)[1].(GradientStop.Color)">
                                           <SplineColorKeyFrame KeyTime="0" Value="#F2FFFFFF"/>
                                        </ColorAnimationUsingKeyFrames>
                                     </Storyboard>
                                  </VisualState>
                                  <VisualState x:Name="Pressed">
                                     <Storyboard>
                                        <ColorAnimationUsingKeyFrames BeginTime="0" Duration="00:00:00.001" Storyboard.TargetName="Background" Storyboard.TargetProperty="(Border.Background).(SolidColorBrush.Color)">
                                           <SplineColorKeyFrame KeyTime="0" Value="#FF448DCA"/>
                                        </ColorAnimationUsingKeyFrames>
                                        <DoubleAnimationUsingKeyFrames BeginTime="0" Duration="00:00:00.001" Storyboard.TargetName="Highlight" Storyboard.TargetProperty="(UIElement.Opacity)">
                                           <SplineDoubleKeyFrame KeyTime="0" Value="1"/>
                                        </DoubleAnimationUsingKeyFrames>
                                        <ColorAnimationUsingKeyFrames BeginTime="0" Duration="00:00:00.001" Storyboard.TargetName="BackgroundGradient" Storyboard.TargetProperty="(Border.Background).(GradientBrush.GradientStops)[1].(GradientStop.Color)">
                                           <SplineColorKeyFrame KeyTime="0" Value="#EAFFFFFF"/>
                                        </ColorAnimationUsingKeyFrames>
                                        <ColorAnimationUsingKeyFrames BeginTime="0" Duration="00:00:00.001" Storyboard.TargetName="BackgroundGradient" Storyboard.TargetProperty="(Border.Background).(GradientBrush.GradientStops)[2].(GradientStop.Color)">
                                           <SplineColorKeyFrame KeyTime="0" Value="#C6FFFFFF"/>
                                        </ColorAnimationUsingKeyFrames>
                                        <ColorAnimationUsingKeyFrames BeginTime="0" Duration="00:00:00.001" Storyboard.TargetName="BackgroundGradient" Storyboard.TargetProperty="(Border.Background).(GradientBrush.GradientStops)[3].(GradientStop.Color)">
                                           <SplineColorKeyFrame KeyTime="0" Value="#6BFFFFFF"/>
                                        </ColorAnimationUsingKeyFrames>
                                        <ColorAnimationUsingKeyFrames BeginTime="0" Duration="00:00:00.001" Storyboard.TargetName="BackgroundGradient" Storyboard.TargetProperty="(Border.Background).(GradientBrush.GradientStops)[0].(GradientStop.Color)">
                                           <SplineColorKeyFrame KeyTime="0" Value="#F4FFFFFF"/>
                                        </ColorAnimationUsingKeyFrames>
                                     </Storyboard>
                                  </VisualState>
                                  <VisualState x:Name="Disabled">
                                     <Storyboard>
                                        <DoubleAnimationUsingKeyFrames BeginTime="0" Duration="00:00:00.001" Storyboard.TargetName="DisabledVisual" Storyboard.TargetProperty="(UIElement.Opacity)">
                                           <SplineDoubleKeyFrame KeyTime="0" Value="1"/>
                                        </DoubleAnimationUsingKeyFrames>
                                     </Storyboard>
                                  </VisualState>
                               </VisualStateGroup>
                            </VisualStateManager.VisualStateGroups>
                            <Grid Height="18" HorizontalAlignment="Center" Margin="0" VerticalAlignment="Center" Width="19" Background="#11FFFFFF">
                               <Grid.RowDefinitions>
                                  <RowDefinition Height="23*"/>
                                  <RowDefinition Height="19*"/>
                                  <RowDefinition Height="19*"/>
                                  <RowDefinition Height="19*"/>
                               </Grid.RowDefinitions>
                               <Grid.ColumnDefinitions>
                                  <ColumnDefinition Width="20*"/>
                                  <ColumnDefinition Width="20*"/>
                                  <ColumnDefinition Width="20*"/>
                                  <ColumnDefinition Width="20*"/>
                               </Grid.ColumnDefinitions>
                               <Border x:Name="Highlight" Margin="-1" Opacity="0" Grid.ColumnSpan="4" Grid.Row="0" Grid.RowSpan="4" BorderBrush="#FF6DBDD1" BorderThickness="1" CornerRadius="0,0,1,1"/>
                               <Border x:Name="Background" Margin="0,-1,0,0" Opacity="1" Grid.ColumnSpan="4" Grid.Row="1" Grid.RowSpan="3" Background="#FF1F3B53" BorderBrush="#FFFFFFFF" BorderThickness="1" CornerRadius=".5"/>
                               <Border x:Name="BackgroundGradient" Margin="0,-1,0,0" Opacity="1" Grid.ColumnSpan="4" Grid.Row="1" Grid.RowSpan="3" BorderBrush="#BF000000" BorderThickness="1" CornerRadius=".5">
                                  <Border.Background>
                                     <LinearGradientBrush EndPoint=".7,1" StartPoint=".7,0">
                                        <GradientStop Color="#FFFFFFFF" Offset="0"/>
                                        <GradientStop Color="#F9FFFFFF" Offset="0.375"/>
                                        <GradientStop Color="#E5FFFFFF" Offset="0.625"/>
                                        <GradientStop Color="#C6FFFFFF" Offset="1"/>
                                     </LinearGradientBrush>
                                  </Border.Background>
                               </Border>
                               <Rectangle StrokeThickness="1" Grid.ColumnSpan="4" Grid.RowSpan="1">
                                  <Rectangle.Stroke>
                                     <LinearGradientBrush EndPoint="0.48,-1" StartPoint="0.48,1.25">
                                        <GradientStop Color="#FF494949"/>
                                        <GradientStop Color="#FF9F9F9F" Offset="1"/>
                                     </LinearGradientBrush>
                                  </Rectangle.Stroke>
                                  <Rectangle.Fill>
                                     <LinearGradientBrush EndPoint="0.3,-1.1" StartPoint="0.46,1.6">
                                        <GradientStop Color="#FF4084BD"/>
                                        <GradientStop Color="#FFAFCFEA" Offset="1"/>
                                     </LinearGradientBrush>
                                  </Rectangle.Fill>
                               </Rectangle>
                               <Path Fill="#FF2F2F2F" Stretch="Fill" HorizontalAlignment="Center" Margin="4,3,4,3" VerticalAlignment="Center" RenderTransformOrigin="0.5,0.5" Grid.Column="0" Grid.ColumnSpan="4" Grid.Row="1" Grid.RowSpan="3" Data="M11.426758,8.4305077 L11.749023,8.4305077 L11.749023,16.331387 L10.674805,16.331387 L10.674805,10.299648 L9.0742188,11.298672 L9.0742188,10.294277 C9.4788408,10.090176 9.9094238,9.8090878 10.365967,9.4510155 C10.82251,9.0929432 11.176106,8.7527733 11.426758,8.4305077 z M14.65086,8.4305077 L18.566387,8.4305077 L18.566387,9.3435936 L15.671368,9.3435936 L15.671368,11.255703 C15.936341,11.058764 16.27293,10.960293 16.681133,10.960293 C17.411602,10.960293 17.969301,11.178717 18.354229,11.615566 C18.739157,12.052416 18.931622,12.673672 18.931622,13.479336 C18.931622,15.452317 18.052553,16.438808 16.294415,16.438808 C15.560365,16.438808 14.951641,16.234707 14.468243,15.826504 L14.881817,14.929531 C15.368796,15.326992 15.837872,15.525723 16.289043,15.525723 C17.298809,15.525723 17.803692,14.895514 17.803692,13.635098 C17.803692,12.460618 17.305971,11.873379 16.310528,11.873379 C15.83071,11.873379 15.399232,12.079271 15.016094,12.491055 L14.65086,12.238613 z"/>
                               <Ellipse Fill="#FFFFFFFF" StrokeThickness="0" Height="3" HorizontalAlignment="Center" VerticalAlignment="Center" Width="3" Grid.ColumnSpan="4"/>
                               <Border x:Name="DisabledVisual" Opacity="0" Grid.ColumnSpan="4" Grid.Row="0" Grid.RowSpan="4" BorderBrush="#B2FFFFFF" BorderThickness="1" CornerRadius="0,0,.5,.5"/>
                            </Grid>
                         </Grid>
                      </ControlTemplate>
                   </Grid.Resources>
                   <VisualStateManager.VisualStateGroups>
                      <VisualStateGroup x:Name="CommonStates">
                         <VisualState x:Name="Normal"/>
                         <VisualState x:Name="Disabled">
                            <Storyboard>
                               <DoubleAnimation Duration="0" Storyboard.TargetName="DisabledVisual" Storyboard.TargetProperty="Opacity" To="1"/>
                            </Storyboard>
                         </VisualState>
                      </VisualStateGroup>
                   </VisualStateManager.VisualStateGroups>
                   <Grid.ColumnDefinitions>
                      <ColumnDefinition Width="*"/>
                      <ColumnDefinition Width="Auto"/>
                   </Grid.ColumnDefinitions>
                   <System_Windows_Controls_Primitives:DatePickerTextBox x:Name="TextBox" Background="{TemplateBinding Background}" BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" Padding="{TemplateBinding Padding}" Grid.Column="0" SelectionBackground="{TemplateBinding SelectionBackground}"/>
                   <Button x:Name="Button" Margin="2,0,2,0" Width="20" BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" Foreground="{TemplateBinding Foreground}" Template="{StaticResource DropDownButtonTemplate}" Grid.Column="1"/>
                   <Grid x:Name="DisabledVisual" IsHitTestVisible="False" Opacity="0" Grid.ColumnSpan="2">
                      <Grid.ColumnDefinitions>
                         <ColumnDefinition Width="*"/>
                         <ColumnDefinition Width="Auto"/>
                      </Grid.ColumnDefinitions>
                      <Rectangle Fill="#8CFFFFFF" RadiusX="1" RadiusY="1"/>
                      <Rectangle Fill="#8CFFFFFF" RadiusX="1" RadiusY="1" Height="18" Margin="2,0,2,0" Width="19" Grid.Column="1"/>
                   </Grid>
                   <Popup x:Name="Popup"/>
                </Grid>
             </ControlTemplate>
          </Setter.Value>
       </Setter>
    </Style>
