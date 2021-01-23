    <Window.Resources>
    		<Style x:Key="CrazyButtonStyle" TargetType="{x:Type Button}">
    			<Setter Property="Template">
    				<Setter.Value>
    					<ControlTemplate TargetType="{x:Type Button}">
    						<Grid>
    							<VisualStateManager.VisualStateGroups>
    								<VisualStateGroup x:Name="CommonStates">
    									<VisualState x:Name="Normal">
    										<Storyboard>
    											<ColorAnimationUsingKeyFrames Storyboard.TargetProperty="(Shape.Fill).(GradientBrush.GradientStops)[1].(GradientStop.Color)" Storyboard.TargetName="path">
    												<EasingColorKeyFrame KeyTime="0" Value="#FFBEBEBE"/>
    											</ColorAnimationUsingKeyFrames>
    											<ColorAnimationUsingKeyFrames Storyboard.TargetProperty="(Shape.Fill).(GradientBrush.GradientStops)[0].(GradientStop.Color)" Storyboard.TargetName="path">
    												<EasingColorKeyFrame KeyTime="0" Value="#FF919191"/>
    											</ColorAnimationUsingKeyFrames>
    										</Storyboard>
    									</VisualState>
    									<VisualState x:Name="MouseOver">
    										<Storyboard>
    											<ColorAnimationUsingKeyFrames Storyboard.TargetProperty="(Shape.Fill).(GradientBrush.GradientStops)[0].(GradientStop.Color)" Storyboard.TargetName="path">
    												<EasingColorKeyFrame KeyTime="0" Value="#FF782B2B"/>
    											</ColorAnimationUsingKeyFrames>
    										</Storyboard>
    									</VisualState>
    									<VisualState x:Name="Pressed">
    										<Storyboard>
    											<ColorAnimationUsingKeyFrames Storyboard.TargetProperty="(Shape.Fill).(GradientBrush.GradientStops)[0].(GradientStop.Color)" Storyboard.TargetName="path">
    												<EasingColorKeyFrame KeyTime="0" Value="#FF1D0C0C"/>
    											</ColorAnimationUsingKeyFrames>
    										</Storyboard>
    									</VisualState>
    									<VisualState x:Name="Disabled">
    										<Storyboard>
    											<ColorAnimationUsingKeyFrames Storyboard.TargetProperty="(Shape.Fill).(GradientBrush.GradientStops)[0].(GradientStop.Color)" Storyboard.TargetName="path">
    												<EasingColorKeyFrame KeyTime="0" Value="#FF720505"/>
    											</ColorAnimationUsingKeyFrames>
    											<ColorAnimationUsingKeyFrames Storyboard.TargetProperty="(Shape.Fill).(GradientBrush.GradientStops)[1].(GradientStop.Color)" Storyboard.TargetName="path">
    												<EasingColorKeyFrame KeyTime="0" Value="#FF6E0000"/>
    											</ColorAnimationUsingKeyFrames>
    										</Storyboard>
    									</VisualState>
    								</VisualStateGroup>
    							</VisualStateManager.VisualStateGroups>
    							<Path x:Name="path" Data="M95.5,33.499981 C71.500031,31.499967 76.5,68.5 76.5,68.5 L112.5,75.500276 107.5,92.500393 144.5,105.50048 152.5,79.500301 132.5,63.50019 154.5,54.500128 173.5,68.500225 168.5,87.500356 172.5,97.500425 185.5,96.500418 197.12084,75.753906 200.12084,44.753692 176.5,34.49999 143.5,32.499975 142.5,13.499841 130.5,28.499946 137.5,41.500036 135.5,51.500106 117.5,52.500113 99.5,54.500126 116.5,39.500022 z" Stretch="Fill" Stroke="{x:Null}">
    								<Path.Fill>
    									<LinearGradientBrush EndPoint="0.5,1" StartPoint="0.5,0">
    										<GradientStop Color="Black" Offset="0"/>
    										<GradientStop Color="White" Offset="1"/>
    									</LinearGradientBrush>
    								</Path.Fill>
    							</Path>
    							<ContentPresenter HorizontalAlignment="Right" RecognizesAccessKey="True" SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}" VerticalAlignment="Top" Margin="0,24.52,18.715,0"/>
    						</Grid>
    						<ControlTemplate.Triggers>
    							<Trigger Property="IsFocused" Value="True"/>
    							<Trigger Property="IsDefaulted" Value="True"/>
    							<Trigger Property="IsMouseOver" Value="True"/>
    							<Trigger Property="IsPressed" Value="True"/>
    							<Trigger Property="IsEnabled" Value="False"/>
    						</ControlTemplate.Triggers>
    					</ControlTemplate>
    				</Setter.Value>
    			</Setter>
    		</Style>
    	</Window.Resources>
