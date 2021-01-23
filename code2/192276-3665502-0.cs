    <style x:Key="roundButton" TargetType="Button">
        <Setter Properties="Template">
            <Setter.Value>
                  <ControlTemplate TargetType="Button">
                     <Ellipse width="100" height="100">
                         <Ellipse.Fill>
                                <ImageBrush ImageSource="./icon.png">
                         </Ellipse.Fill>
                     </Ellipse>
    
                     <ControlTemplate.Triggers>
                        <Trigger Property="IsMouseOver" Value="True">
                           <!-- mouse over look and feel here -->
                        </Trigger>
                        <Trigger Property="IsPressed" Value="True">
                           <!-- clicked look and feel here -->
                        </Trigger>
                        </ControlTemplate.Triggers> 
                  </ControlTemplate>
            </Setter.Value>
        </Setter>
    </style>
