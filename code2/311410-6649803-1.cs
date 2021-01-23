    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using ASPSandcastleWPFClient.ASPSandcastleWebserviceClient;
    
    namespace ASPSandcastleWPFClient
    {
    	/// <summary>
    	/// Interaction logic for MainWindow.xaml
    	/// </summary>
    	public partial class MainWindow : Window
    	{
    		private ASPSandcastleWebservice myClient = null;
    		private AsyncCallHelper myHelloWorldHelper = null;
    
    		public MainWindow()
    		{
    			InitializeComponent();
    		}
    
    		private void InitializeClient()
    		{
    			myClient = new ASPSandcastleWebservice();
    			myHelloWorldHelper = 
    				new AsyncCallHelper
    					(
    						myClient.HelloWorldAsync,
    						HelloWorldTimeout
    					);
    		}
    
    		private void Window_Initialized(object sender, EventArgs e)
    		{
    			InitializeClient();
    		}
    
    		/// <summary>
    		/// this is called prior to making a call so that we do not end up with multiple
    		/// outstanding async calls
    		/// </summary>
    		private void DisableButtons()
    		{
    			btnStartAsyncCall.IsEnabled = false;
    			btnStartAsyncCallWithTimeout.IsEnabled = false;
    		}
    
    		/// <summary>
    		/// this is called after a result is received or the call is cancelled due to timeout
    		/// so that we know it's safe to make another call.
    		/// </summary>
    		private void EnableButtons()
    		{
    			btnStartAsyncCall.IsEnabled = true;
    			btnStartAsyncCallWithTimeout.IsEnabled = true;
    		}
    
    		private void btnStartAsyncCall_Click(object sender, RoutedEventArgs e)
    		{
    			DisableButtons();
    			
    			// disable the timeout handling
    			AsyncCallHelper.DefaultTimeout = TimeSpan.Zero;
    
    			myClient.HelloWorldCompleted += new HelloWorldCompletedEventHandler(myClient_HelloWorldCompleted);
    
    			myHelloWorldHelper.BeginAsyncCall();
    			lblResponse.Content = "waiting...";
    		}
    
    		private void btnStartAsyncCallWithTimeout_Click(object sender, RoutedEventArgs e)
    		{
    			DisableButtons();
    
    			// enable the timeout handling
    			AsyncCallHelper.DefaultTimeout = TimeSpan.FromSeconds(10);
    			lblResponse.Content = "waiting for 10 seconds...";
    			myHelloWorldHelper.BeginAsyncCall();
    		}
    
    		/// <summary>
    		/// see note RE: possible multi-thread issues when not using WPF in AsyncCallHelper.cs
    		/// </summary>
    		private void HelloWorldTimeout()
    		{
    			myClient.CancelAsync(null);
    			lblResponse.Content = "call timed out...";
    			EnableButtons();
    		}
    
    		void myClient_HelloWorldCompleted(object sender, HelloWorldCompletedEventArgs e)
    		{
    			myHelloWorldHelper.CallComplete();
    
    			if (!e.Cancelled)
    				lblResponse.Content = e.Result;
    
    			EnableButtons();
    		}
    	}
    }
