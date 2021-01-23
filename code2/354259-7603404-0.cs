    using System;
    using System.Threading;
    namespace Thread.Pool.Test
    {
    	delegate void VoidDelegate (object obj);
    	
    	public class Delegate
    	{
    		/// <summary>
    		/// ThreadPool Entry Point for A
    		/// </summary>
    		/// <param name='obj'>
    		/// EventWaitHandle
    		/// </param>
    		/// <exception cref='ArgumentException'>
    		/// Is thrown when an argument passed to a method is invalid.
    		/// </exception>
    		private void A (object obj) {
    			if (!(obj is EventWaitHandle))
    				throw new ArgumentException ("Only EventWaitHandle supported!");
    			A ((EventWaitHandle)obj);
    		}
    
    		private void A (EventWaitHandle handle) {
    			// does one thing
    			
    			//finsihed
    			handle.Set ();
    		}
    		
    		/// <summary>
    		/// ThreadPool Entry Point for B
    		/// </summary>
    		/// <param name='obj'>
    		/// EventWaitHandle
    		/// </param>
    		/// <exception cref='ArgumentException'>
    		/// Is thrown when an argument passed to a method is invalid.
    		/// </exception>
    		private void B (object obj) {
    			if (!(obj is EventWaitHandle))
    				throw new ArgumentException ("Only EventWaitHandle supported!");
    			B ((EventWaitHandle)obj);
            
    		}
    		
    		private void B (EventWaitHandle handle) {
    			// does a different thing
    			
    			//finsihed
    			handle.Set ();
    		}
    
    		private void C (int i) {
    			EventWaitHandle waitHandle = new ManualResetEvent (false);
    			switch (i) {
    			case 1:
    				D (A ,waitHandle);
    				break;
    			case 2:
    				D (B ,waitHandle);
    				break;
    			default:
    				throw new Exception ("Case not supported");
    			}
    			//Wait for the thread to finish
    			waitHandle.WaitOne ();
    		}
    
    		private void D (VoidDelegate any, EventWaitHandle waitHandle) { 
    			ThreadPool.QueueUserWorkItem (new System.Threading.WaitCallback (any),waitHandle);
    		}
    
    	}
    }
