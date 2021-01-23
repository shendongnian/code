    using System;
    
    
    namespace MCSharp {
    
    
    	/**	<summary>
    		Implements a queue based around a singly linked list.</summary>
    		<remarks>
    		The .NET's built in queue implementation uses a dynamically-resizing array
    		for its data storage.</remarks>
    	*/
    	public class LinkedQueue<T> {
    	
    	
    		private class SinglyLinkedListNode<NodeT> {
    		
    			
    			public SinglyLinkedListNode<NodeT> Next=null;
    			public NodeT Item;
    			
    			
    			public SinglyLinkedListNode (NodeT item) {
    			
    				Item=item;
    			
    			}
    			
    		
    		}
    		
    		
    		private SinglyLinkedListNode<T> head=null;
    		private SinglyLinkedListNode<T> tail=null;
    		private Int32 count=0;
    		
    		
    		/**	<summary>
    			Returns the number of items in the queue.</summary>
    		*/
    		public Int32 Count {
    		
    			get {	return count;	}
    		
    		}
    		
    		
    		/**	<summary>
    			Creates a new queue.</summary>
    		*/
    		public LinkedQueue () {	}
    		
    		
    		/**	<summary>
    			Adds an item to the rear of the queue.</summary>
    			<param name="item">
    			The item to add to the queue.</param>
    		*/
    		public void Enqueue (T item) {
    		
    			SinglyLinkedListNode<T> newnode=new SinglyLinkedListNode<T>(item);
    			
    			count++;
    			
    			if (head==null) {
    			
    				head=newnode;
    				tail=newnode;
    			
    			} else {
    			
    				tail.Next=newnode;
    				tail=newnode;
    			
    			}
    		
    		}
    		
    		
    		/**	<summary>
    			Returns the item at the front of the queue.</summary>
    			<returns>
    			The item at the front of the queue.</returns>
    		*/
    		public T Dequeue () {
    		
    			if (count==0) throw new InvalidOperationException();
    			
    			T returnthis=head.Item;
    			
    			if (head.Next==null) tail=null;
    			
    			head=head.Next;
    			
    			count--;
    			
    			return returnthis;
    		
    		}
    	
    	
    	}
    
    
    }
