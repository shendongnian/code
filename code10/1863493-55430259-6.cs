    using System;                                                                                                                                                                                                                                                                  
    using System.Globalization;                                                                            
    using System.Windows.Data;                                                                             
    using System.Windows.Media;                                                                            
                                                                                                           
    namespace Contrats_Congeles.Library                                                                    
    {                                                                                                      
        [ValueConversion(typeof(string), typeof(SolidColorBrush))]                                         
        public class BackgroundConverter_Yellow : IValueConverter                                          
        {                                                                                                  
                                                                                                           
            public Brush YellowBrush { get; set; }                                                         
            public Brush TransparentBrush { get; set; }                                                    
                                                                                                           
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)    
            {                                                                                              
                                                                                                           
                if (value == null || value.ToString().Length == 0)                                         
                {                                                                                          
                    return YellowBrush;                                                                    
                }                                                                                          
                else                                                                                       
                {                                                                                          
                    return TransparentBrush;                                                               
                }                                                                                          
            }                                                                                              
                                                                                                           
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {                                                                                              
                throw new NotImplementedException();                                                       
            }                                                                                              
        }                                                                                                  
    }                                                                                                      
