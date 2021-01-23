    using System;
    using System.Diagnostics;
    using System.Runtime;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Threading;
    namespace System
    {
    	[DebuggerDisplay("ThreadSafetyMode={Mode}, IsValueCreated={IsValueCreated}, IsValueFaulted={IsValueFaulted}, Value={ValueForDebugDisplay}"), DebuggerTypeProxy(typeof(System_LazyDebugView)), ComVisible(false)]
    	[Serializable]
    	public class Lazy<T>
    	{
    		[Serializable]
    		private class Boxed
    		{
    			internal T m_value;
    			[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    			internal Boxed(T value)
    			{
    				this.m_value = value;
    			}
    		}
    		private class LazyInternalExceptionHolder
    		{
    			internal Exception m_exception;
    			[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    			internal LazyInternalExceptionHolder(Exception ex)
    			{
    				this.m_exception = ex;
    			}
    		}
    		private static Func<T> PUBLICATION_ONLY_OR_ALREADY_INITIALIZED = () => default(T);
    		private object m_boxed;
    		[NonSerialized]
    		private Func<T> m_valueFactory;
    		[NonSerialized]
    		private readonly object m_threadSafeObj;
    		internal T ValueForDebugDisplay
    		{
    			get
    			{
    				if (!this.IsValueCreated)
    				{
    					return default(T);
    				}
    				return ((Lazy<T>.Boxed)this.m_boxed).m_value;
    			}
    		}
    		internal LazyThreadSafetyMode Mode
    		{
    			get
    			{
    				if (this.m_threadSafeObj == null)
    				{
    					return LazyThreadSafetyMode.None;
    				}
    				if (this.m_threadSafeObj == Lazy<T>.PUBLICATION_ONLY_OR_ALREADY_INITIALIZED)
    				{
    					return LazyThreadSafetyMode.PublicationOnly;
    				}
    				return LazyThreadSafetyMode.ExecutionAndPublication;
    			}
    		}
    		internal bool IsValueFaulted
    		{
    			get
    			{
    				return this.m_boxed is Lazy<T>.LazyInternalExceptionHolder;
    			}
    		}
    		public bool IsValueCreated
    		{
    			[TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
    			get
    			{
    				return this.m_boxed != null && this.m_boxed is Lazy<T>.Boxed;
    			}
    		}
    		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
    		public T Value
    		{
    			get
    			{
    				if (this.m_boxed == null)
    				{
    					Debugger.NotifyOfCrossThreadDependency();
    					return this.LazyInitValue();
    				}
    				Lazy<T>.Boxed boxed = this.m_boxed as Lazy<T>.Boxed;
    				if (boxed != null)
    				{
    					return boxed.m_value;
    				}
    				Lazy<T>.LazyInternalExceptionHolder lazyInternalExceptionHolder = this.m_boxed as Lazy<T>.LazyInternalExceptionHolder;
    				throw lazyInternalExceptionHolder.m_exception;
    			}
    		}
    		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    		public Lazy() : this(LazyThreadSafetyMode.ExecutionAndPublication)
    		{
    		}
    		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    		public Lazy(Func<T> valueFactory) : this(valueFactory, LazyThreadSafetyMode.ExecutionAndPublication)
    		{
    		}
    		public Lazy(bool isThreadSafe) : this(isThreadSafe ? LazyThreadSafetyMode.ExecutionAndPublication : LazyThreadSafetyMode.None)
    		{
    		}
    		public Lazy(LazyThreadSafetyMode mode)
    		{
    			this.m_threadSafeObj = Lazy<T>.GetObjectFromMode(mode);
    		}
    		public Lazy(Func<T> valueFactory, bool isThreadSafe) : this(valueFactory, isThreadSafe ? LazyThreadSafetyMode.ExecutionAndPublication : LazyThreadSafetyMode.None)
    		{
    		}
    		public Lazy(Func<T> valueFactory, LazyThreadSafetyMode mode)
    		{
    			if (valueFactory == null)
    			{
    				throw new ArgumentNullException("valueFactory");
    			}
    			this.m_threadSafeObj = Lazy<T>.GetObjectFromMode(mode);
    			this.m_valueFactory = valueFactory;
    		}
    		private static object GetObjectFromMode(LazyThreadSafetyMode mode)
    		{
    			if (mode == LazyThreadSafetyMode.ExecutionAndPublication)
    			{
    				return new object();
    			}
    			if (mode == LazyThreadSafetyMode.PublicationOnly)
    			{
    				return Lazy<T>.PUBLICATION_ONLY_OR_ALREADY_INITIALIZED;
    			}
    			if (mode != LazyThreadSafetyMode.None)
    			{
    				throw new ArgumentOutOfRangeException("mode", Environment.GetResourceString("Lazy_ctor_ModeInvalid"));
    			}
    			return null;
    		}
    		[OnSerializing]
    		private void OnSerializing(StreamingContext context)
    		{
    			T arg_06_0 = this.Value;
    		}
    		public override string ToString()
    		{
    			if (!this.IsValueCreated)
    			{
    				return Environment.GetResourceString("Lazy_ToString_ValueNotCreated");
    			}
    			T value = this.Value;
    			return value.ToString();
    		}
    		private T LazyInitValue()
    		{
    			Lazy<T>.Boxed boxed = null;
    			LazyThreadSafetyMode mode = this.Mode;
    			if (mode == LazyThreadSafetyMode.None)
    			{
    				boxed = this.CreateValue();
    				this.m_boxed = boxed;
    			}
    			else
    			{
    				if (mode == LazyThreadSafetyMode.PublicationOnly)
    				{
    					boxed = this.CreateValue();
    					if (Interlocked.CompareExchange(ref this.m_boxed, boxed, null) != null)
    					{
    						boxed = (Lazy<T>.Boxed)this.m_boxed;
    					}
    				}
    				else
    				{
    					lock (this.m_threadSafeObj)
    					{
    						if (this.m_boxed == null)
    						{
    							boxed = this.CreateValue();
    							this.m_boxed = boxed;
    						}
    						else
    						{
    							boxed = (this.m_boxed as Lazy<T>.Boxed);
    							if (boxed == null)
    							{
    								Lazy<T>.LazyInternalExceptionHolder lazyInternalExceptionHolder = this.m_boxed as Lazy<T>.LazyInternalExceptionHolder;
    								throw lazyInternalExceptionHolder.m_exception;
    							}
    						}
    					}
    				}
    			}
    			return boxed.m_value;
    		}
    		private Lazy<T>.Boxed CreateValue()
    		{
    			Lazy<T>.Boxed result = null;
    			LazyThreadSafetyMode mode = this.Mode;
    			if (this.m_valueFactory != null)
    			{
    				try
    				{
    					if (mode != LazyThreadSafetyMode.PublicationOnly && this.m_valueFactory == Lazy<T>.PUBLICATION_ONLY_OR_ALREADY_INITIALIZED)
    					{
    						throw new InvalidOperationException(Environment.GetResourceString("Lazy_Value_RecursiveCallsToValue"));
    					}
    					Func<T> valueFactory = this.m_valueFactory;
    					if (mode != LazyThreadSafetyMode.PublicationOnly)
    					{
    						this.m_valueFactory = Lazy<T>.PUBLICATION_ONLY_OR_ALREADY_INITIALIZED;
    					}
    					result = new Lazy<T>.Boxed(valueFactory());
    					return result;
    				}
    				catch (Exception arg_5B_0)
    				{
    					Exception exception = arg_5B_0;
    					if (mode != LazyThreadSafetyMode.PublicationOnly)
    					{
    						this.m_boxed = new Lazy<T>.LazyInternalExceptionHolder(exception.PrepForRemoting());
    					}
    					throw;
    				}
    			}
    			try
    			{
    				result = new Lazy<T>.Boxed((T)Activator.CreateInstance(typeof(T)));
    			}
    			catch (MissingMethodException )
    			{
    				Exception exception2 = new MissingMemberException(Environment.GetResourceString("Lazy_CreateValue_NoParameterlessCtorForT"));
    				if (mode != LazyThreadSafetyMode.PublicationOnly)
    				{
    					this.m_boxed = new Lazy<T>.LazyInternalExceptionHolder(exception2);
    				}
    				throw exception2;
    			}
    			return result;
    		}
    	}
    }
