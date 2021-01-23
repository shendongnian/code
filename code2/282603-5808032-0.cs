    <Image Name="imgMin"
           Grid.Column="0"
           Stretch="UniformToFill"
           Cursor="Hand" 
           MouseDown="imgMin_MouseDown">
           <Image.Style> 
               <Style> 
                   <Setter Property="Image.Source">
                     <Setter.Value>
                       <Binding Source="{x:Static res:AppResources.minimize}">
                         <Binding.Converter>
                           <Helpers:IconToImageSourceConverter/>
                         </Binding.Converter>
                       </Binding>
                     </Setter.Value>
                   </Setter>
                   <Style.Triggers>                                                                  
                       <Trigger Property="Image.IsMouseOver" Value="True">                           
                         <Setter Property="Image.Source">
                           <Setter.Value>
                             <Binding Source="{x:Static res:AppResources.minimize_glow}">
                               <Binding.Converter>
                                 <Helpers:IconToImageSourceConverter/>
                               </Binding.Converter>
                             </Binding>
                           </Setter.Value>
                         </Setter>
                       </Trigger>                                                                
                   </Style.Triggers>
                </Style> 
            </Image.Style>
    </Image>
