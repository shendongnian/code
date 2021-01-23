	public class FixedIntDictionary<T>
	{
		// Our internal node structure.
		// We use structs instead of objects to not add pressure to the garbage collector.
		// We mantains our own way to manage garbage through the use of a free list.
		private struct Entry
		{
			// The key of the node
			internal int Key;
			
			// Next index in pEntries array.
			// This field is both used in the free list, if node was removed
			// or in the table, if node was inserted.
			// -1 means null.
			internal int Next;
			// The value of the node.
			internal T Value;
		}
		
		// The actual hash table. Contains indices to pEntries array.
		// The hash table can be seen as an array of singlt linked list.
		// We store indices to pEntries array instead of objects for performance
		// and to avoid pressure to the garbage collector.
		// An index -1 means null.
		private int[] pBuckets;
		// This array contains the memory for the nodes of the dictionary.
		private Entry[] pEntries;
		
		// This is the first node of a singly linked list of free nodes.
		// This data structure is called the FreeList and we use it to
		// reuse removed nodes instead of allocating new ones.
		private int pFirstFreeEntry;
		// Contains simply the number of items in this dictionary.
		private int pCount;
		
		// Contains the number of used entries (both in the dictionary or in the free list) in pEntries array.
		// This field is going only to grow with insertions.
		private int pEntriesCount;
		
		///<summary>
		/// Creates a new FixedIntDictionary. 
		/// tableBucketsCount should be a prime number
		/// greater than the number of items that this
		/// dictionary should store.
		/// The performance of this hash table will be very bad
		/// if you don't follow this rule!
		/// </summary>
		public FixedIntDictionary<T>(int tableBucketsCount)
		{
			// Our free list is initially empty.
			this.pFirstFreeEntry = -1;
			// Initializes the entries array with a minimal amount of items.
			this.pEntries = new Entry[8];
			// Allocate buckets and initialize every linked list as empty.
			int[] buckets = new int[capacity];
			for (int i = 0; i < buckets.Length; ++i)
				buckets[i] = -1;
			this.pBuckets = buckets;
		}
		
		///<summary>Gets the number of items in this dictionary. Complexity is O(1).</summary>
		public int Count
		{
			get { return this.pCount; }
		}
		
		///<summary>
		/// Adds a key value pair to the dictionary.
		/// Complexity is averaged O(1).
		/// Returns false if the key already exists.
		/// </summary>
		public bool Add(int key, T value)
		{
			// The hash table can be seen as an array of linked list.
			// We find the right linked list using hash codes.
			// Since the hash code of an integer is the integer itself, we have a perfect hash.
			
			// After we get the hash code we need to remove the sign of it.
			// To do that in a fast way we and it with 0x7FFFFFFF, that means, we remove the sign bit.
			// Then we have to do the modulus of the found hash code with the size of our buckets array.
			// For this reason the size of our bucket array should be a prime number,
			// this because the more big is the prime number, the less is the chance to find an
			// hash code that is divisible for that number. This reduces collisions.
			
			// This implementation will not grow the buckets table when needed, this is the major
			// problem with this implementation.
			// Growing requires a little more code that i don't want to write now
			// (we need a function that finds prime numbers, and it should be fast and we
			// need to rehash everything using the new buckets array).
			
			int bucketIndex = (key & 0x7FFFFFFF) % this.pBuckets.Length;
			int bucket = this.pBuckets[bucketIndex];
			
			// Now we iterate in the linked list of nodes.
			// Since this is an hash table we hope these lists are very small.
			// If the number of buckets is good and the hash function is good this will translate usually 
			// in a O(1) operation.
			Entry[] entries = this.pEntries;
			for (int current = entries[bucket]; current != -1; current = entries[current].Next)
			{
				if (entries[current].Key == key)
				{
					// Entry already exists.
					return false;
				}
			}
			
			// Ok, key not found, we can add the new key and value pair.
			
			int entry = this.pFirstFreeEntry;
			if (entry != -1)
			{
				// We found a deleted node in the free list.
				// We can use that node without "allocating" another one.
				this.pFirstFreeEntry = entries[entry].Next;
			}
			else
			{
				// Mhhh ok, the free list is empty, we need to allocate a new node.
				// First we try to use an unused node from the array.
				entry = this.pEntriesCount++;
				if (entry >= this.pEntries)
				{
					// Mhhh ok, the entries array is full, we need to make it bigger.
					// Here should go also the code for growing the bucket table, but i'm not writing it here.
					Array.Resize(ref this.pEntries, this.pEntriesCount * 2);
					entries = this.pEntries;
				}
			}
			
			// Ok now we can add our item.
			// We just overwrite key and value in the struct stored in entries array.
			
			entries[entry].Key = key;
			entries[entry].Value = value;
			// Now we add the entry in the right linked list of the table.
			entries[entry].Next = this.pBuckets[bucketIndex];
			this.pBuckets[bucketIndex] = entry;
			
			// Increments total number of items.
			++this.pCount;
			
			return true;
		}
		
		/// <summary>
		/// Gets a value that indicates wether the specified key exists or not in this table.
		/// Complexity is averaged O(1).
		/// </summary>
		public bool Contains(int key)
		{
			// This translate in a simple linear search in the linked list for the right bucket.
			// The operation, if array size is well balanced and hash function is good, will be almost O(1).
			int bucket = this.pBuckets[(key & 0x7FFFFFFF) % this.pBuckets.Length];
			Entry[] entries = this.pEntries;
			for (int current = entries[bucket]; current != -1; current = entries[current].Next)
			{
				if (entries[current].Key == key)
				{
					return true;
				}
			}
			return false;
		}
		
		/// <summary>
		/// Removes the specified item from the dictionary.
		/// Returns true if item was found and removed, false if item doesn't exists.
		/// Complexity is averaged O(1).
		/// </summary>
		public bool Remove(int key)
		{
			// Removal translate in a simple contains and removal from a singly linked list.
			// Quite simple.
			
			int bucketIndex = (key & 0x7FFFFFFF) % this.pBuckets.Length;
			int bucket = this.pBuckets[bucketIndex];
			Entry[] entries = this.pEntries;
			int next;
			int prev = -1;
			int current = entries[bucket];
			
			while (current != -1)
			{
				next = entries[current].Next;
				if (entries[current].Key == key)
				{
					// Found! Remove from linked list.
					if (prev != -1)
						entries[prev].Next = next;
					else
						this.pBuckets[bucketIndex] = next;
						
					// We now add the removed node to the free list,
					// so we can use it later if we add new elements.
					entries[current].Next = this.pFirstFreeEntry;
					this.pFirstFreeEntry = current;
					
					// Decrements total number of items.
					--this.pCount;
					return true;
				}
				
				prev = current;
				current = next;
			}
			return false;
		}
		
	}
