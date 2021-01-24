<Style TargetType="{x:Type Button}">
    <Setter Property="Template">
         <Setter.Value>
              <ControlTemplate TargetType="Button">
                  <TextBlock
                      x:Name="TblockTest"
                      Background="Gray"
                      Foreground="Blue">
                      <ContentPresenter x:Name="CpCustomButton" ContentSource="Content">
                          <ContentPresenter.Resources>
                              <Style TargetType="TextBlock">
                                  <Setter Property="Foreground" Value="Green" />
                              </Style>
                          </ContentPresenter.Resources>
                      </ContentPresenter>
                  </TextBlock>
                  <ControlTemplate.Triggers>
                      <Trigger Property="IsMouseOver" Value="False">
                          <Setter TargetName="CpCustomButton" Property="TextBlock.Foreground" Value="Black" />
                      </Trigger>
                  </ControlTemplate.Triggers>
              </ControlTemplate>
         </Setter.Value>
    </Setter>
</Style>
I'm not sure why it didn't use the style from the TextBlock.Resources when that is a parent to the ContentPresenter.
Hope that helps. Michal
