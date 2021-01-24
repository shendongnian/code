    using LiveCharts.Defaults;
    using LiveCharts.Geared;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    
    namespace bughunt
    {
    	/// <summary>
    	/// Interaction logic for MainWindow.xaml
    	/// </summary>
    	public partial class MainWindow : Window
    	{
    		public IGearedValues Values { get; set; }
    
    		public MainWindow()
    		{
    			const int count = 1000;
    
    			//Not sorting causes crashes when zooming deep in and back
    			const bool SortBeforePassing = false;
    
    			var r = new Random();
    
    			var datepointlist = new List<DateTimePoint>();
    
    			for (int i = 0; i < count; i++)
    			{
    				datepointlist.Add(new DateTimePoint(DateTime.Now.AddHours(-i), (double)r.Next(1, 150)));
    			}
    			if (SortBeforePassing)
    			{
    				Values = datepointlist.OrderBy(x => x.DateTime).AsGearedValues().WithQuality(Quality.High);
    			}
    			else
    			{
    				Values = datepointlist.AsGearedValues().WithQuality(Quality.High);
    			}
    
    			DataContext = this;
    			InitializeComponent();
    		}
    	}
    }
