        public class TruncateMe : DependencyObject, IValueConverter
        {
             public static readonly DependencyProperty MaxLengthProperty =
                 DependencyProperty.Register("MaxLength",
                                              typeof(int),
                                              typeof(TruncateMe),
                                              new PropertyMetadata(100));
             public int MaxLength
             {
                 get { return (int) this.GetValue(MaxLengthProperty); }
                 set { this.SetValue(MaxLengthProperty, value); }
             }
             public object Convert(object value, /*rest of parameters*/ )
             {
                string s = value.ToString();
                if ( s.Length > MaxLength)
                  return s.Substring(0, MaxLength) + "...";
              else
                  return s;
             }
             //...
        }
      In XAML, you can directly use it as:
        <TextBlock>
           <TextBlock.Text>
               <Binding Path="FullDescription">
                   <Binding.Converter>
                     <local:TruncateMe MaxLength="50"/>
                   </Binding.Converter>
               </Binding>
           </TextBlock.Text> 
       </TextBlock>
       
      What does it do? It truncates the string `FullDescription` if it is more than `50` characters!
