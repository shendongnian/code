                            <TextBlock Text="{Binding MyPath}" TextWrapping="Wrap">
                                <i:Interaction.Triggers>
                                    <i:EventTrigger EventName="Loaded">
                                        <cmdex:EventToCommand Command="{Binding Source={StaticResource InlineConverter}, Path=ConvertTextToInlinesCommand}" CommandParameter="{Binding RelativeSource={RelativeSource Self}}" />
                                    </i:EventTrigger>
                                </i:Interaction.Triggers>
                            </TextBlock>
