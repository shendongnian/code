	public class TextBoxStringAnimation : StringAnimationBase {
		public static readonly DependencyProperty TextBoxToChangeProperty = DependencyProperty.Register(nameof(TextBoxToChange), typeof(TextBox), typeof(TextBoxStringAnimation));
		public TextBox TextBoxToChange {
			get => (TextBox)this.GetValue(TextBoxToChangeProperty);
			set => this.SetValue(TextBoxToChangeProperty, value);
		}
		public static readonly DependencyProperty NewTextProperty = DependencyProperty.Register(nameof(NewText), typeof(string), typeof(TextBoxStringAnimation));
		public string NewText {
			get => (string)this.GetValue(NewTextProperty);
			set => this.SetValue(NewTextProperty, value);
		}
		protected override Freezable CreateInstanceCore() => new TextBoxStringAnimation();
		protected override string GetCurrentValueCore(string defaultOriginValue, string defaultDestinationValue, AnimationClock animationClock) {
			TextBoxToChange.Text = NewText;
			return defaultDestinationValue;
		}
		protected override bool FreezeCore(bool isChecking) {
			return true;
		}
	}
This inherits from StringAnimationBase, and you can set the TextBox and the NewText values directly. I have implemented both as dependency properties, so you can bind them.
When getting the current value (GetCurrentValueCore) it simply sets the Text property of the target TextBox. I had to override FreezeCore, because by default it has returned false, and that causes an InvelidOperationException when the animation is triggered.
So this is an animation that does not animate at all. :) I consider this an ugly solution, but without using a user control I could not come up with a better solution.
Below is the XAML markup. You must set the TargetProperty of the animation, although at the end it is not used - that is why I have specified Tag. If you use the Tag property of the textbox, check if the animation resets it or not.
		<Style x:Key="mystyle" TargetType="{x:Type TextBox}">
			<Setter Property="Template">
				<Setter.Value>
					<ControlTemplate TargetType="{x:Type TextBox}">
						<StackPanel>
							<ScrollViewer x:Name="PART_ContentHost" Focusable="false" HorizontalScrollBarVisibility="Auto" VerticalScrollBarVisibility="Auto" />
							<ToggleButton HorizontalAlignment="Right" VerticalAlignment="Top" Content="search" Name="searchButton">
								<ToggleButton.Triggers>
									<EventTrigger RoutedEvent="Button.Click">
										<BeginStoryboard>
											<Storyboard>
												<local:TextBoxStringAnimation TextBoxToChange="{Binding RelativeSource={RelativeSource AncestorType=TextBox,AncestorLevel=1}}"
																			  NewText="texttwo" Storyboard.TargetProperty="(TextBox.Tag)"/>
											</Storyboard>
										</BeginStoryboard>
									</EventTrigger>
								</ToggleButton.Triggers>
							</ToggleButton>
						</StackPanel>
					</ControlTemplate>
				</Setter.Value>
			</Setter>
		</Style>
