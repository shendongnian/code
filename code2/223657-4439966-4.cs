    <Style x:Key="DatePickerTextBoxStyle" TargetType="System_Windows_Controls_Primitives:DatePickerTextBox">
       <Setter Property="VerticalContentAlignment" Value="Center"/>
       <Setter Property="HorizontalContentAlignment" Value="Left"/>
       <Setter Property="Template">
          <Setter.Value>
             <ControlTemplate TargetType="System_Windows_Controls_Primitives:DatePickerTextBox">
                <Grid x:Name="Root">
                   <Grid.Resources>
                      <SolidColorBrush x:Key="WatermarkBrush" Color="#FFAAAAAA"/>
                   </Grid.Resources>
                   <VisualStateManager.VisualStateGroups>
                      <VisualStateGroup x:Name="CommonStates">
                         <VisualStateGroup.Transitions>
                            <VisualTransition GeneratedDuration="0"/>
                            <VisualTransition GeneratedDuration="0:0:0.1" To="MouseOver"/>
                         </VisualStateGroup.Transitions>
                         <VisualState x:Name="Normal"/>
                         <VisualState x:Name="MouseOver">
                            <Storyboard>
                               <ColorAnimationUsingKeyFrames Storyboard.TargetProperty="(Border.BorderBrush).(SolidColorBrush.Color)" Storyboard.TargetName="ContentElement">
                                  <SplineColorKeyFrame KeyTime="0" Value="#FF99C1E2"/>
                               </ColorAnimationUsingKeyFrames>
                               <ColorAnimationUsingKeyFrames Storyboard.TargetProperty="(Border.BorderBrush).(SolidColorBrush.Color)" Storyboard.TargetName="ContentElement2">
                                  <SplineColorKeyFrame KeyTime="0" Value="#FF99C1E2"/>
                               </ColorAnimationUsingKeyFrames>
                            </Storyboard>
                         </VisualState>
                      </VisualStateGroup>
                      <VisualStateGroup x:Name="WatermarkStates">
                         <VisualStateGroup.Transitions>
                            <VisualTransition GeneratedDuration="0"/>
                         </VisualStateGroup.Transitions>
                         <VisualState x:Name="Unwatermarked"/>
                         <VisualState x:Name="Watermarked">
                            <Storyboard>
                               <DoubleAnimation Duration="0" To="0" Storyboard.TargetProperty="Opacity" Storyboard.TargetName="ContentElement"/>
                               <DoubleAnimation Duration="0" To="1" Storyboard.TargetProperty="Opacity" Storyboard.TargetName="Watermark"/>
                            </Storyboard>
                         </VisualState>
                      </VisualStateGroup>
                      <VisualStateGroup x:Name="FocusStates">
                         <VisualStateGroup.Transitions>
                            <VisualTransition GeneratedDuration="0"/>
                         </VisualStateGroup.Transitions>
                         <VisualState x:Name="Unfocused"/>
                         <VisualState x:Name="Focused">
                            <Storyboard>
                               <DoubleAnimation Duration="0" To="1" Storyboard.TargetProperty="Opacity" Storyboard.TargetName="FocusVisual"/>
                            </Storyboard>
                         </VisualState>
                      </VisualStateGroup>
                   </VisualStateManager.VisualStateGroups>
                   <Border x:Name="Border" BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" CornerRadius="1" Opacity="1">
                      <Grid x:Name="WatermarkContent" Background="{TemplateBinding Background}">
                         <Border x:Name="ContentElement" BorderBrush="#FFFFFFFF" BorderThickness="1" Background="{TemplateBinding Background}" Padding="{TemplateBinding Padding}"/>
                         <Border x:Name="ContentElement2" BorderBrush="#FFFFFFFF" BorderThickness="1">
                            <ContentControl x:Name="Watermark" Background="{TemplateBinding Background}" Content="{TemplateBinding Watermark}" Foreground="{StaticResource WatermarkBrush}" FontSize="{TemplateBinding FontSize}" HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" HorizontalContentAlignment="{TemplateBinding HorizontalContentAlignment}" IsHitTestVisible="False" IsTabStop="False" Opacity="0" Padding="2" VerticalAlignment="{TemplateBinding VerticalContentAlignment}" VerticalContentAlignment="{TemplateBinding VerticalContentAlignment}"/>
                         </Border>
                         <Border x:Name="FocusVisual" BorderBrush="#FF6DBDD1" BorderThickness="{TemplateBinding BorderThickness}" CornerRadius="1" IsHitTestVisible="False" Opacity="0"/>
                      </Grid>
                   </Border>
                </Grid>
             </ControlTemplate>
          </Setter.Value>
       </Setter>
    </Style> 
   
