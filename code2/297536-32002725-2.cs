    using Microsoft.VisualBasic;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Web;
    using System.Threading.Tasks;
    using System.Threading;
    
    public class Directory4 : System.Web.UI.Page
    {
    
    	private static CancellationTokenSource cts = null;
    	private static object LockObj = new object();
    	private static int SillyValue = 0;
    	private static bool bInterrupted = false;
    
    	private static bool bAllDone = false;
    
    	protected void Page_Load(object sender, System.EventArgs e)
    	{
    	}
    
    
    
    	protected void DoStatusMessage(string Msg)
    	{
    		this.lblMessages.Text = Msg;
    		Debug.Print(Msg);
    	}
    
    
    	protected void btn_Start_Click(object sender, EventArgs e)
    	{
    		if ((cts != null)) {
    			if (!cts.IsCancellationRequested) {
    				DoStatusMessage("Please cancel the running process first.");
    				return;
    			}
    			cts.Dispose();
    			cts = null;
    			DoStatusMessage("Plase cancel the running process or wait for it to complete.");
    		}
    		bInterrupted = false;
    		bAllDone = false;
    		CancellationTokenSource ncts = new CancellationTokenSource();
    		cts = ncts;
    
    		// Pass the token to the cancelable operation.
    		ThreadPool.QueueUserWorkItem(new WaitCallback(DoSomeWork), cts.Token);
    		DoStatusMessage("This Task has now started.");
    
    		Timer1.Interval = 1000;
    		Timer1.Enabled = true;
    	}
    
    	protected void StopThread()
    	{
    		if ((cts == null))
    			return;
    		lock ((LockObj)) {
    			cts.Cancel();
    			System.Threading.Thread.SpinWait(1);
    			cts.Dispose();
    			cts = null;
    			bAllDone = true;
    		}
    
    
    	}
    
    	protected void btn_Stop_Click(object sender, EventArgs e)
    	{
    		if (bAllDone) {
    			DoStatusMessage("Nothing running. Start the task if you like.");
    			return;
    		}
    		bInterrupted = true;
    		btn_Start.Enabled = true;
    
    		StopThread();
    
    		DoStatusMessage("This Canceled Task has now been gently terminated.");
    	}
    
    
    	public void Refresh_Parent_Webpage_and_Exit()
    	{
    		//***** This refreshes the parent page.
    		String csname1 = "Exit_from_Dir4";
    		Type cstype = GetType();
    
    		// Get a ClientScriptManager reference from the Page class.
    		ClientScriptManager cs = Page.ClientScript;
    
    		// Check to see if the startup script is already registered.
    		if (!cs.IsStartupScriptRegistered(cstype, csname1)) {
    			StringBuilder cstext1 = new StringBuilder();
    			cstext1.Append("<script language=javascript>window.close();</script>");
    			cs.RegisterStartupScript(cstype, csname1, cstext1.ToString());
    		}
    	}
    
    
    	//Thread 2: The worker
    	public static void DoSomeWork(CancellationToken token)
    	{
    		int i = 0;
    
    		if ((token == null)) {
    			Debug.Print("Empty cancellation token passed.");
    			return;
    		}
    
    		lock ((LockObj)) {
    			SillyValue = 0;
    
    		}
    
    
    		//Dim token As CancellationToken = CType(obj, CancellationToken)
    
    		for (i = 0; i <= 10; i++) {
    			// Simulating work.
    			System.Threading.Thread.Yield();
    
    			Thread.Sleep(1000);
    			lock ((LockObj)) {
    				SillyValue += 1;
    			}
    			if (token.IsCancellationRequested) {
    				lock ((LockObj)) {
    					bAllDone = true;
    				}
    				break; // TODO: might not be correct. Was : Exit For
    			}
    		}
    		lock ((LockObj)) {
    			bAllDone = true;
    		}
    	}
    
    	protected void Timer1_Tick(object sender, System.EventArgs e)
    	{
    		//    '***** This is for ending the task normally.
    
    
    		if (bAllDone) {
    			if (bInterrupted) {
    				DoStatusMessage("Processing terminated by user");
    
    			} else {
    				DoStatusMessage("This Task has has completed normally.");
    			}
    
    			//Timer1.Change(System.Threading.Timeout.Infinite, 0)
    			Timer1.Enabled = false;
    			StopThread();
    
    			return;
    		}
    		DoStatusMessage("Working:" + Convert.ToString(SillyValue));
    
    	}
    	public Directory4()
    	{
    		Load += Page_Load;
    	}
    }
