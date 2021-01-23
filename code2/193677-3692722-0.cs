    <Canvas Grid.Row="2" Background="Transparent">
       <Polyline Points="25,25 0,50 25,75 50,50 25,25 25,0" 
                 Stroke="Blue" StrokeThickness="10"
                 Canvas.Left="75" Canvas.Top="50">
          <Polyline.RenderTransform>
              <RotateTransform CenterX="0" CenterY="0" Angle="45" />
          </Polyline.RenderTransform>
       </Polyline>
       <Canvas.Style>
           <Style TargetType="{x:Type Canvas}">
              <Style.Triggers>
                  <Trigger Property="IsMouseOver" Value="True" >
                    <Setter Property="Cursor" Value="Cross" />
                  </Trigger>
              </Style.Triggers>
            </Style>
       </Canvas.Style>
    </Canvas>
