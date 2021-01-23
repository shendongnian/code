    <TabItem>
        <TabItem.Style>
             <Style TargetType="TabItem">
                  <Setter Property="Header">
                      <Setter.Value>
                          <Image ...>
                      </Setter.Value>
                  </Setter>
                  <Style.Triggers>
                      <Trigger Property="IsSelected" Value="True">
                          <Setter Property="Header">
                              <Setter.Value>
                                  <Image ...>
                              </Setter.Value>
                          </Setter>
                      </Trigger>
                  </Style.Triggers>
             </Style>
        </TabItem.Style>
    </TabItem>
