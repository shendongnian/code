    using System;
    using System.Threading;
    
    
    namespace MCSharp {
    
    
    	/**	<summary>
    		A thread safe, blocking queue.</summary>
    		<remarks>
    		All members of this class are thread safe.</remarks>
    	*/
    	public class MessageQueue<T> {
    	
    	
    		private LinkedQueue<T> messagequeue=new LinkedQueue<T>();
    		private Object waitobject=new Object();
    		private Int32 numwaitingthreads=0;
    		private Object emptyobject=new Object();
    		
    		
    		/**	<summary>
    			Returns the number of items currently waiting in the queue.</summary>
    		*/
    		public Int32 MessageCount {
    		
    			get {	lock (waitobject) return messagequeue.Count;	}
    		
    		}
    		
    		
    		/**	<summary>
    			Returns the number of threads currently waiting for items to be added to the queue.</summary>
    		*/
    		public Int32 ThreadCount {
    		
    			get {	lock (waitobject) return numwaitingthreads;	}
    		
    		}
    		
    		
    		/**	<summary>
    			Creates a new queue.</summary>
    		*/
    		public MessageQueue () {	}
    		
    		
    		/**	<summary>
    			Adds a new item to the back of the queue.</summary>
    			<param name="message">
    			The item to add to the queue.</param>
    		*/
    		public void Enqueue (T message) {
    		
    			lock (waitobject) {
    			
    				messagequeue.Enqueue(message);
    				
    				Monitor.Pulse(waitobject);
    			
    			}
    		
    		}
    		
    		
    		/**	<summary>
    			Removes an item from the front of the queue.</summary>
    			<remarks>
    			If there is currently no item at the front of the queue the thread will block
    			until there is one, and then return with that item.</remarks>
    			<returns>
    			The item from the front of the queue.</returns>
    		*/
    		public T Dequeue () {
    		
    			lock (waitobject) {
    			
    				while (messagequeue.Count==0) {
    				
    					numwaitingthreads++;
    				
    					Monitor.Wait(waitobject);
    					
    					numwaitingthreads--;
    				
    				}
    				
    				lock (emptyobject) {
    				
    					Monitor.PulseAll(emptyobject);
    					
    					return messagequeue.Dequeue();
    					
    				}
    			
    			}
    		
    		}
    		
    		
    		/**	<summary>
    			Waits for the queue to empty.</summary>
    			<remarks>
    			The calling thread blocks until the thread's <see cref="MCSharp.MessageQueue{T}.MessageCount">
    			message count</see> is zero.</remarks>
    		*/
    		public void WaitForEmpty () {
    		
    			while (true) {
    			
    				Monitor.Enter(waitobject);
    				
    				try {
    				
    					if (messagequeue.Count==0) {
    					
    						return;
    					
    					}
    					
    					Monitor.Enter(emptyobject);
    					
    				} finally {
    				
    					Monitor.Exit(waitobject);
    				
    				}
    				
    				try {
    				
    					Monitor.Wait(emptyobject);
    				
    				} finally {
    				
    					Monitor.Exit(emptyobject);
    				
    				}
    			
    			}
    		
    		}
    		
    	
    	}
    
    
    }
