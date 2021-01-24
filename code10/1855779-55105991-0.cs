    <ListView ScrollViewer.VerticalScrollMode="Auto" ScrollViewer.HorizontalScrollMode="Disabled" ScrollViewer.HorizontalScrollBarVisibility="Disabled">
        <ListView.Template>
            <ControlTemplate TargetType="ListView">
                <Border Background="{TemplateBinding Background}" BorderThickness="{TemplateBinding BorderThickness}" BorderBrush="{TemplateBinding BorderBrush}">
                    <ScrollViewer x:Name="ScrollViewer" AutomationProperties.AccessibilityView="Raw" BringIntoViewOnFocusChange="{TemplateBinding ScrollViewer.BringIntoViewOnFocusChange}" HorizontalScrollBarVisibility="{TemplateBinding ScrollViewer.HorizontalScrollBarVisibility}" HorizontalScrollMode="{TemplateBinding ScrollViewer.HorizontalScrollMode}" IsDeferredScrollingEnabled="{TemplateBinding ScrollViewer.IsDeferredScrollingEnabled}" IsVerticalScrollChainingEnabled="{TemplateBinding ScrollViewer.IsVerticalScrollChainingEnabled}" IsHorizontalRailEnabled="{TemplateBinding ScrollViewer.IsHorizontalRailEnabled}" IsVerticalRailEnabled="{TemplateBinding ScrollViewer.IsVerticalRailEnabled}" IsHorizontalScrollChainingEnabled="{TemplateBinding ScrollViewer.IsHorizontalScrollChainingEnabled}" TabNavigation="{TemplateBinding TabNavigation}" VerticalScrollMode="{TemplateBinding ScrollViewer.VerticalScrollMode}" VerticalScrollBarVisibility="{TemplateBinding ScrollViewer.VerticalScrollBarVisibility}" ZoomMode="{TemplateBinding ScrollViewer.ZoomMode}">
                        <StackPanel>
                            <ContentPresenter Content="{TemplateBinding Header}" ContentTemplate="{TemplateBinding HeaderTemplate}"/>
                            <ItemsPresenter Padding="{TemplateBinding Padding}"/>
                        </StackPanel>
                    </ScrollViewer>
                </Border>
            </ControlTemplate>
        </ListView.Template>
    </ListView>
