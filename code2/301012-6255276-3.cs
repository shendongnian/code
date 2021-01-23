    <Style TargetType="{x:Type ListViewItem}">
    	<Style.Triggers>
    		<DataTrigger
    				Binding="{Binding RelativeSource={RelativeSource Self}, Path=IsKeyboardFocusWithin, Mode=OneWay}"
    				Value="True">
    			<DataTrigger.EnterActions>
    				<BeginStoryboard>
    					<Storyboard>
    						<BooleanAnimationUsingKeyFrames Storyboard.TargetProperty="IsSelected">
    							<DiscreteBooleanKeyFrame KeyTime="0" Value="True" />
    						</BooleanAnimationUsingKeyFrames>
    					</Storyboard>
    				</BeginStoryboard>
    			</DataTrigger.EnterActions>
    		</DataTrigger>
    	</Style.Triggers>
    </Style>
