    <Application>
      <Application.Resources>
        <ResourceDictionary>
          <Style TargetType="TreeViewItem">
            <Setter Property="ContextMenu">
              <Setter.Value>
                <ContextMenu>
                  <MenuItem Header="_Bold"
                            IsCheckable="True"
                            Checked="Bold_Checked"
                            Unchecked="Bold_Unchecked" />
                  <MenuItem Header="_Italic"
                            IsCheckable="True"
                            Checked="Italic_Checked"
                            Unchecked="Italic_Unchecked" />
                  <Separator />
                  <MenuItem Header="Increase Font Size"
                            Click="IncreaseFont_Click" />
                  <MenuItem Header="_Decrease Font Size"
                            Click="DecreaseFont_Click" />
                </ContextMenu>
              </Setter.Value>
            </Setter>
          </Style>
        </ResourceDictionary>
      </Application.Resources>
    </Application>
