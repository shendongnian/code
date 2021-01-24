    <Window ...>
        <Window.Resources>
            <Storyboard x:Key="OpenMenu">
                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(FrameworkElement.Opacity)" >
                    <EasingDoubleKeyFrame KeyTime="0" Value="1"/>
                    <EasingDoubleKeyFrame KeyTime="0:0:0.5" Value="0"/>
                </DoubleAnimationUsingKeyFrames>
            </Storyboard>
            <Storyboard x:Key="CloseMenu">
                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(FrameworkElement.Opacity)" >
                    <EasingDoubleKeyFrame KeyTime="0" Value="1"/>
                    <EasingDoubleKeyFrame KeyTime="0:0:0.5" Value="1"/>
                </DoubleAnimationUsingKeyFrames>
            </Storyboard>
            <Style TargetType="TextBox" x:Key="companyStyle" >
                <Style.Triggers>
                    <DataTrigger Binding="{Binding Path=SelectedValue, ElementName=comboBoxRole}" Value="AppDeveloper">
                        <DataTrigger.EnterActions>
                            <BeginStoryboard Name="sb" Storyboard="{StaticResource OpenMenu}"/>
                        </DataTrigger.EnterActions>
                        <DataTrigger.ExitActions>
                            <RemoveStoryboard BeginStoryboardName="sb" />
                        </DataTrigger.ExitActions>
                    </DataTrigger>
                    <DataTrigger Binding="{Binding Path=SelectedValue, ElementName=comboBoxRole}" Value="EndUser">
                        <DataTrigger.EnterActions>
                            <BeginStoryboard Name="sb2" Storyboard="{StaticResource CloseMenu}"/>
                        </DataTrigger.EnterActions>
                        <DataTrigger.ExitActions>
                            <RemoveStoryboard BeginStoryboardName="sb2" />
                        </DataTrigger.ExitActions>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </Window.Resources>
        <StackPanel Margin="10">
            <TextBox Style="{StaticResource companyStyle}" />
            <ComboBox x:Name="comboBoxRole" SelectedValuePath="Content">
                <ComboBoxItem>AppDeveloper</ComboBoxItem>
                <ComboBoxItem>EndUser</ComboBoxItem>
            </ComboBox>
        </StackPanel>
    </Window>
