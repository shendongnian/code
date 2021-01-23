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
    using System.Collections.ObjectModel;
    
    namespace MyProject
    {
    	public partial class MainPage : UserControl
    	{
    		private ObservableCollection<Student> m_Students = new ObservableCollection<Student>();
    		
    		public MainPage()
    		{
    			InitializeComponent();
    			this.Loaded += new RoutedEventHandler(UC_Loaded);
    		}
    
    		public ObservableCollection<Student> Students
    		{
    			get { return m_Students; }
    			set { m_Students = value; }
    		}
    
    		void UC_Loaded(object sender, RoutedEventArgs e)
    		{
    			//int student_id = (int)App.Current.Resources["student_id"];
    			int student_id = 10; // no need to type cast.
    			//int test_id = (int)App.Current.Resources["test_id"];
    
    			this.DataContext = Students;
    
    			if (student_id == 10)
    			{
    				Students.Add(new Student() { Date = "14th Oct", Result = 30 });
    				Students.Add(new Student() { Date = "20th Oct", Result = 60 });
    				Students.Add(new Student() { Date = "30th Oct", Result = 20 });
    				Students.Add(new Student() { Date = "12th Nov", Result = 10 });
    				Students.Add(new Student() { Date = "20th Nov", Result = 70 });
    			}
    			else
    			{
    				Students.Add(new Student() { Date = "14th Oct", Result = 10 });
    				Students.Add(new Student() { Date = "20th Oct", Result = 10 });
    				Students.Add(new Student() { Date = "30th Oct", Result = 10 });
    				Students.Add(new Student() { Date = "12th Nov", Result = 10 });
    				Students.Add(new Student() { Date = "20th Nov", Result = 10 });
    			}
    		}
    	}
    
    	public class Student : INotifyLayoutChange
    	{
    		private string m_Date;
    		private int m_Result;
    		
    		public event PropertyChangedEventHandler PropertyChanged;
    		
    		public string Date 
    		{ 
    			get { return m_Date; } 
    			set
    			{
    				if (m_Date == value)
    					return; // return values are the same, no update needed.
    				m_Date = value;
    				RaisePropertyChanged("Date");
    			}
    		}
    		
    		public int Result 
    		{ 
    			get { return m_Result; }
    			set
    			{
    				if (m_Result == value)
    					return;
    				m_Result = value;
    				RaisePropertyChanged("Result");
    			}
    		}
    
    		private void RaisePropertyChanged(string propertyName)
    		{
    			if (PropertyChanged != null)
    				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    		}
    	}
    }
