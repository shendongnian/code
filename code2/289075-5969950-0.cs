    <Style d:IsControlPart="True" TargetType="{x:Type local:ModelTreeViewItem}">
		<Setter Property="IsSelected" Value="{Binding IsSelected, Mode=TwoWay}" />
		<Setter Property="NeedsFocus" Value="{Binding NeedsFocus, Mode=TwoWay}" />
                    <ControlTemplate.Triggers>
						<Trigger Property="NeedsFocus" Value="true">
							<Trigger.Setters>
								<Setter Property="FocusManager.FocusedElement" Value="{Binding RelativeSource={RelativeSource Self}}"></Setter>
							</Trigger.Setters>
						</Trigger>
                    </ControlTemplate.Triggers>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
