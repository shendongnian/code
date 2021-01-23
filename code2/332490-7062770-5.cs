    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Animation;
    using System.Windows.Shapes;
    
    using System.Reflection;
    
    namespace SilverlightApplication1
    {
    	public partial class MainPage : UserControl
    	{
    		public MainPage()
    		{
    			InitializeComponent();
    		}
    
    		[Flags]
    		enum Insects { Creepy = 0x0001, Creepier = 0x0002, Creepiest = 0x0004 };
    
    		enum Cats { Fluffy, Furry, Bald };
    		enum Dogs { Big, Fat, Ugly };
    		enum Rodents { Cute = 3, Cuter = 7, Cutest = 32 };
    
    		static Type CurrentEnum = typeof(Cats);
    
    		private void btnRunTests_Click(object sender, RoutedEventArgs e)
    		{
    			// from original test code
    			Int32 i = (Int32)Enum.Parse(CurrentEnum, "Bald", true);
    
    			i = i == CurrentEnum.GetEnumValues().Length - 1 ? 0 : i + 1;
    			String nextValue = CurrentEnum.GetEnumValues().GetValue(i).ToString();
    
    			textBlock1.Text += nextValue + Environment.NewLine;
    
    			// new test code
    			LogEnum(typeof(Cats));
    			LogEnum(typeof(Dogs));
    			LogEnum(typeof(Rodents));
    			LogEnum(typeof(Insects));
    		}
    
    		public void LogEnum(Type T)
    		{
    			Array CurrentEnumValues;
    			CurrentEnumValues = T.GetEnumValues();
    
    			for (int i=0; i < CurrentEnumValues.Length; ++i)
    			{
    				string EnumName = CurrentEnumValues.GetValue(i).ToString();
    				int EnumValue = (int)CurrentEnumValues.GetValue(i);
    				textBlock1.Text += "[" + EnumName + " = " + EnumValue.ToString() + "], ";
    			}
    
    			textBlock1.Text += Environment.NewLine;
    		}
    	}
    }
